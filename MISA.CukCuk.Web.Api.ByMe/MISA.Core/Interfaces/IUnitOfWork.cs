using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{   /// <summary>
/// 
/// Danh sách các phương thức của các entity đều có thể được gọi qua đây
/// created by DTHieu(13/04/2021)
/// </summary>
    public interface IUnitOfWork
    {
        
        /// <summary>
        /// Gọi các phương thức của ICountryRepository qua country
        /// created by DTHieu(13/04/2021)
        /// </summary>
        ICountryRepository Country { get; }
        /// <summary>
        /// Gọi các phương thức của IProvinceRepository qua province
        /// created by DTHieu(13/04/2021)
        /// </summary>
        IProvinceRepository Province { get; }
        /// <summary>
        /// Gọi các phương thức của IDistrictRepository qua district
        /// created by DTHieu(13/04/2021)
        /// </summary>
        IDistrictRepository District { get; }
        /// <summary>
        /// Gọi các phương thức của IWardRepository qua ward
        /// created by DTHieu(13/04/2021)
        /// </summary>
        IWardRepository Ward { get; }
        /// <summary>
        /// Gọi các phương thức của IStoreRepository qua store
        /// created by DTHieu(13/04/2021)
        /// </summary>
        IStoreRepository Store { get; }
    }
}
