using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public IEnumerable<Province> GetProvinceWithCountry(Guid countryId)
        {
            var storeName = $"Proc_GetProvinceWithCountry";
            var storeParam = new
            {
                Id = countryId
            };

            var entities = _dbConnection.Query<Province>(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return (entities);
        }
    }
    
}
