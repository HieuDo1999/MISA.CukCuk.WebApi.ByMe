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
        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            string storeNames = "Proc_GetStoreFilter";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("StoreCode", storeCode);
            dynamicParameters.Add("StoreName", storeName);
            dynamicParameters.Add("Address", address);
            dynamicParameters.Add("PhoneNumber", phoneNumber);
            dynamicParameters.Add("Status", status);
                
            var entities = _dbConnection.Query<Store>(storeNames, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return (entities);
        }
        public IEnumerable<Store> GetStoreByStoreCode(string storeCode)
        {
            string storeNames = "Proc_GetStoreByStoreCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("StoreCode", storeCode);
            var entities = _dbConnection.Query<Store>(storeNames, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return (entities);
        }
    }
}
