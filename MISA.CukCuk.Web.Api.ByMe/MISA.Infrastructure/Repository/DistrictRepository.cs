using Dapper;
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
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public IEnumerable<District> GetDistrictWithProvince(Guid provinceId)
        {
            var storeName = $"Proc_GetDistrictWithProvince";
            var storeParam = new
            {
                Id = provinceId
            };

            var entities = _dbConnection.Query<District>(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return (entities);
        }
    }
}
