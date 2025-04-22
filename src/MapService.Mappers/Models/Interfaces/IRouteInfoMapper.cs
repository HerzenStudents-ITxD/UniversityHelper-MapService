using System.Collections.Generic;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models.Interfaces;

[AutoInject]
public interface IRouteInfoMapper
{
  List<PointInfo> Map(List<DbPoint> dbPoints);
}