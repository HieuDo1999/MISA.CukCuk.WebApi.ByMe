using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IStoreService:IBaseService<Store>
    {
        /// <summary>
        /// Lấy dữ liệu danh sách của store theo 4 params
        /// </summary>
        /// <param name="storeCode"></param>
        /// <param name="storeName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="status"></param>
        /// <returns>danh sách store </returns>
        /// create by DTHieu(14/4/2021)
        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);
        /// <summary>
        /// Lấy dữ liệu của store theo store code
        /// </summary>
        /// <param name="storeCode"></param>
        /// <returns>Store</returns>
        /// created by DTHieu(14/4/2021))
        public IEnumerable<Store> GetStoreByStoreCode(string storeCode);
        /// <summary>
        /// Lấy dữ liệu danh sách của store theo vị trí bắt đầu và số lượng bản ghi của 1 trang
        /// </summary>
        /// <param name="positionStart"></param>
        /// <param name="positionOffset"></param>
        /// <returns>stores </returns>
        /// creared by DTHieu(16/4/2021)

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int positionOffset);
        /// <summary>
        /// 
        /// Lấy dữ liệu danh sách store đã được lọc theo param và được phân trang
        /// </summary>
        /// <param name="positionStart"></param>
        /// <param name="positionOffset"></param>
        /// <param name="storeCode"></param>
        /// <param name="storeName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="status"></param>
        /// <returns>danh sách stores</returns>
        /// created by DTHieu(19/04/2021)
        public IEnumerable<Store> GetStoreFilterByIndexOffset(int positionStart, int positionOffset, string storeCode, string storeName, string address, string phoneNumber, int? status);

        /// <summary>
        /// Lấy số lượng bản ghi store
        /// </summary>
        /// <returns>số lượng bản ghi store</returns>
        /// created by DTHieu(27/04/2021)
        public int GetCountStores();
    }
}
