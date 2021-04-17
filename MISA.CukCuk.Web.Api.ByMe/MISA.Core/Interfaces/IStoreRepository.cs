using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);

        public IEnumerable<Store> GetStoreByStoreCode(string storeCode);

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int positionOffset);

        public int GetCountStores();
    }
}
