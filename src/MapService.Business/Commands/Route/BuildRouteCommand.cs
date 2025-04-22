using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.MapService.Business.Commands.Route.Interfaces;
using UniversityHelper.MapService.Data.Interfaces;
using UniversityHelper.MapService.Mappers.Models.Interfaces;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;
using UniversityHelper.MapService.Models.Dto.Requests.Filters;

namespace UniversityHelper.MapService.Business.Commands.Route;

public class BuildRouteCommand : IBuildRouteCommand
{
  private readonly IRelationRepository _relationRepository;
  private readonly IPointRepository _pointRepository;
  private readonly IRouteInfoMapper _mapper;

  public BuildRouteCommand(
      IRelationRepository relationRepository,
      IPointRepository pointRepository,
      IRouteInfoMapper mapper)
  {
    _relationRepository = relationRepository;
    _pointRepository = pointRepository;
    _mapper = mapper;
  }

  public async Task<OperationResultResponse<List<PointInfo>>> ExecuteAsync(BuildRouteFilter filter)
  {
    if (!await _pointRepository.DoesExistAsync(filter.StartPointId) || !await _pointRepository.DoesExistAsync(filter.EndPointId))
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "One or both points not found."
      };
    }

    var relations = await _relationRepository.GetAllAsync();
    var path = FindShortestPath(relations, filter.StartPointId, filter.EndPointId);

    if (path == null || path.Count == 0)
    {
      return new OperationResultResponse<List<PointInfo>>
      {
        StatusCode = HttpStatusCode.NotFound,
        Message = "No route found."
      };
    }

    var points = new List<DbPoint>();
    foreach (var pointId in path)
    {
      var point = await _pointRepository.GetAsync(new GetPointFilter { PointId = pointId, Locale = filter.Locale });
      if (point != null)
      {
        points.Add(point);
      }
    }

    return new OperationResultResponse<List<PointInfo>>
    {
      Body = _mapper.Map(points)
    };
  }

  private List<Guid> FindShortestPath(List<DbRelation> relations, Guid start, Guid end)
  {
    var graph = new Dictionary<Guid, List<(Guid, float)>>();
    foreach (var relation in relations)
    {
      if (!graph.ContainsKey(relation.FirstPointId))
        graph[relation.FirstPointId] = new List<(Guid, float)>();
      if (!graph.ContainsKey(relation.SecondPointId))
        graph[relation.SecondPointId] = new List<(Guid, float)>();

      graph[relation.FirstPointId].Add((relation.SecondPointId, 1f));
      graph[relation.SecondPointId].Add((relation.FirstPointId, 1f));
    }

    var distances = new Dictionary<Guid, float> { { start, 0 } };
    var previous = new Dictionary<Guid, Guid?>();
    var queue = new PriorityQueue<(Guid, float)>();
    queue.Enqueue((start, 0));

    while (queue.Count > 0)
    {
      var (current, currentDistance) = queue.Dequeue();

      if (current == end)
        break;

      if (!graph.ContainsKey(current))
        continue;

      foreach (var (neighbor, weight) in graph[current])
      {
        var distance = currentDistance + weight;

        if (!distances.ContainsKey(neighbor) || distance < distances[neighbor])
        {
          distances[neighbor] = distance;
          previous[neighbor] = current;
          queue.Enqueue((neighbor, distance));
        }
      }
    }

    if (!previous.ContainsKey(end))
      return new List<Guid>();

    var path = new List<Guid>();
    var currentNode = end;
    while (currentNode != start)
    {
      path.Add(currentNode);
      currentNode = previous[currentNode].Value;
    }
    path.Add(start);
    path.Reverse();
    return path;
  }

  private class PriorityQueue<T>
  {
    private readonly List<(T, float)> _elements = new();

    public int Count => _elements.Count;

    public void Enqueue((T, float) item)
    {
      _elements.Add(item);
      _elements.Sort((a, b) => a.Item2.CompareTo(b.Item2));
    }

    public (T, float) Dequeue()
    {
      var item = _elements[0];
      _elements.RemoveAt(0);
      return item;
    }
  }
}