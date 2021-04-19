using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IWardRepository:IBaseRepository<Ward>
    {
        /// <summary>
        /// Lấy danh sách ward theo districtId
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns>danh sách ward</returns>
        /// created by DTHieu(15/04/2021 )
        public IEnumerable<Ward> GetWardWithDistrict(Guid districtId);
    }
}
