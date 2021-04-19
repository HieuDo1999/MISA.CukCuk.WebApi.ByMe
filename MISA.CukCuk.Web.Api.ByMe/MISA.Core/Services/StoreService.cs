using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class StoreService:BaseService<Store> ,IStoreService
    {
        IUnitOfWork _unitOfWork;
        public StoreService(IUnitOfWork unitOfWork, IBaseRepository<Store> baseRepository) : base(unitOfWork, baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Store> GetStoreByStoreCode(string storeCode)
        {
           return  _unitOfWork.Store.GetStoreByStoreCode(storeCode);
        }

        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            return _unitOfWork.Store.GetStoreFilter(storeCode,storeName, address, phoneNumber, status);
        }

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int offset)
        {
            return _unitOfWork.Store.GetStoreByIndexOffset(positionStart, offset);
        }
        public IEnumerable<Store> GetStoreFilterByIndexOffset(int positionStart, int offset, string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            return _unitOfWork.Store.GetStoreFilterByIndexOffset(positionStart, offset,  storeCode,  storeName,  address,  phoneNumber, status);
        }
        public int GetCountStores()
        {
            return _unitOfWork.Store.GetCountStores();
        }



    }
}
