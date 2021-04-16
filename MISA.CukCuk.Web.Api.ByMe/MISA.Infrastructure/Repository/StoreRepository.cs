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
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public IEnumerable<Store> GetStoreFilter(Guid storeCode, string storeName, string address, string phoneNumber, int status)
        {
            var storeNames = $"Proc_GetStoreFilter";
            var storeParam = new
            {   StoreCode=storeCode,
                StoreName=storeName,
                Address=address,
                PhoneNumber=phoneNumber,
                Status=status
            };

            var entities = _dbConnection.Query<Store>(storeNames, param: storeParam, commandType: CommandType.StoredProcedure);
            return (entities);
        }
    }
}
