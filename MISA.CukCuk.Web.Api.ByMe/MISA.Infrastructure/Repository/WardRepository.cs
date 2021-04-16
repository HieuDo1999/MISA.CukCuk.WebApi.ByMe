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
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        public IEnumerable<Ward> GetWardWithDistrict(Guid wardId)
        {
            var storeName = $"Proc_GetWardWithDistrict";
            var storeParam = new
            {
                Id = wardId
            };

            var entities = _dbConnection.Query<Ward>(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return (entities);
        }
    }
    
}
