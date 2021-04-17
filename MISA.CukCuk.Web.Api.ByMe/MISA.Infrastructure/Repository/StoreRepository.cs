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
            if (status == null)
            {
                status = 2;
            }
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

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int offSet)
        {
            string storeNames = "Proc_GetStoreByIndexOffset";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("positionStart", positionStart);
            dynamicParameters.Add("offSet", offSet);
            var entities = _dbConnection.Query<Store>(storeNames, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return (entities);
        }
        public int GetCountStores()
        {
            string storeNames = "Proc_GetCountStores";
            var count = _dbConnection.ExecuteScalar<int>(storeNames, commandType: CommandType.StoredProcedure);
            return count;
        }
    }
}
