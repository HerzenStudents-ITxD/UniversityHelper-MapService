using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.MapService.Models.Db;
using UniversityHelper.MapService.Models.Dto.Models;

namespace UniversityHelper.MapService.Mappers.Models.Interfaces;

[AutoInject]
public interface ILocationInfoMapper
{
  LocationInfo Map(DbPoint dbLocation);
}
