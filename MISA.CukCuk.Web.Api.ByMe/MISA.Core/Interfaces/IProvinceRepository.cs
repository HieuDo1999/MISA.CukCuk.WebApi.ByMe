using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        /// <summary>
        /// Lấy dữ liệu danh sách  của province theo countryId 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>danh sách province  </returns>
        public IEnumerable<Province> GetProvinceWithCountry(Guid countryId);
    }
}
