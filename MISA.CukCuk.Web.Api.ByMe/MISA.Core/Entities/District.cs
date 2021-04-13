using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
   public class District
    {
        /// <summary>
        /// Mã huyện
        /// </summary>
        public Guid DistrictId { get; set; }
        /// <summary>
        /// Tên huyện
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public Guid ProvinceId { get; set; }
    }
}
