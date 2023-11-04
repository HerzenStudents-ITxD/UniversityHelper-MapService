using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;
using HerzenHelper.MapService.Models.Db;
using HerzenHelper.MapService.Models.Dto.Models;

namespace HerzenHelper.MapService.Mappers.Models.Interfaces
{
    [AutoInject]
    public interface ILocationInfoMapper
    {
        LocationInfo Map(DbLocation dbLocation);
    }
}
