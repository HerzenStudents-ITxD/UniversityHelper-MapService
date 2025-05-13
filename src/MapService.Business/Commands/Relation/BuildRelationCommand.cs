using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Relation.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Relation;

public class BuildRelationCommand : IBuildRelationCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IPointInfoMapper _pointInfoMapper;
  private readonly IAccessValidator _accessValidator;

  public BuildRelationCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IPointInfoMapper pointInfoMapper,
      IAccessValidator accessValidator)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _pointInfoMapper = pointInfoMapper;
    _accessValidator = accessValidator;
  }

  public async Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(BuildRelationFilter filter)
  {
    //Проверка прав доступа
    if (!await _accessValidator.IsAdminAsync() && filter.Locale == null)
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        Body = null,
        Errors = new List<string> { "Locale is required for non-admin users." }
      };
    }

    // Получение всех связей между точками
    var relations = await _relationRepository.GetAllAsync();
    if (!relations.Any())
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        Body = null,
        Errors = new List<string> { "No relations found." }
      };
    }

    // Построение графа
    var graph = new Dictionary<Guid, List<(Guid, float)>>();
    foreach (var relation in relations)
    {
      // Предполагаем, что вес связи вычисляется как евклидово расстояние
      var point1 = await _pointRepository.GetAsync(new GetPointFilter { PointId = relation.FirstPointId });
      var point2 = await _pointRepository.GetAsync(new GetPointFilter { PointId = relation.SecondPointId });
      if (point1 == null || point2 == null)
      {
        continue;
      }

      float distance = CalculateDistance(point1, point2);

      if (!graph.ContainsKey(relation.FirstPointId))
      {
        graph[relation.FirstPointId] = new List<(Guid, float)>();
      }

      if (!graph.ContainsKey(relation.SecondPointId))
      {
        graph[relation.SecondPointId] = new List<(Guid, float)>();
      }

      graph[relation.FirstPointId].Add((relation.SecondPointId, distance));
      graph[relation.SecondPointId].Add((relation.FirstPointId, distance));
    }

    // Алгоритм Дейкстры
    var distances = new Dictionary<Guid, float> { { filter.StartPointId, 0 } };
    var previous = new Dictionary<Guid, Guid?>();
    var priorityQueue = new SortedSet<(float Distance, Guid Node)> { (0, filter.StartPointId) };
    var visited = new HashSet<Guid>();

    while (priorityQueue.Any())
    {
      var (currentDistance, currentNode) = priorityQueue.Min;
      priorityQueue.Remove(priorityQueue.Min);

      if (visited.Contains(currentNode))
      {
        continue;
      }

      visited.Add(currentNode);

      if (currentNode == filter.EndPointId)
      {
        break;
      }

      if (!graph.ContainsKey(currentNode))
      {
        continue;
      }

      foreach (var (neighbor, weight) in graph[currentNode])
      {
        if (visited.Contains(neighbor))
        {
          continue;
        }

        float newDistance = currentDistance + weight;
        if (!distances.ContainsKey(neighbor) || newDistance < distances[neighbor])
        {
          distances[neighbor] = newDistance;
          previous[neighbor] = currentNode;
          priorityQueue.Add((newDistance, neighbor));
        }
      }
    }

    // Построение пути
    if (!distances.ContainsKey(filter.EndPointId))
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        Body = null,
        Errors = new List<string> { "No route found." }
      };
    }

    var path = new List<Guid>();
    Guid? current = filter.EndPointId;
    while (current.HasValue)
    {
      path.Add(current.Value);
      current = previous.ContainsKey(current.Value) ? previous[current.Value] : null;
    }
    path.Reverse();

    // Получение информации о точках
    var points = new List<PointInfo>();
    foreach (var pointId in path)
    {
      var point = await _pointRepository.GetAsync(new GetPointFilter { PointId = pointId, Locale = filter.Locale });
      if (point != null)
      {
        points.Add(_pointInfoMapper.Map(point));
      }
    }

    return new OperationResultResponse<List<PointInfo>>
    {
      Body = points
    };
  }

  private float CalculateDistance(DbPoint point1, DbPoint point2)
  {
    return (float)Math.Sqrt(
        Math.Pow(point1.X - point2.X, 2) +
        Math.Pow(point1.Y - point2.Y, 2) +
        Math.Pow(point1.Z - point2.Z, 2));
  }
}