using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerzenHelper.MapService.Models.Db;
using HerzenHelper.MapService.Models.Dto.Models;

namespace HerzenHelper.MapService.Mappers.Models.Interfaces
{
    public interface ILocationInfoMapper
    {
        LocationInfo Map(DbLocation dbLocation);
    }
}
