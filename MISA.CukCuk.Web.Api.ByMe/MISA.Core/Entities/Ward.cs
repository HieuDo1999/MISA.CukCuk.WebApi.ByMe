using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Ward
    {
        /// <summary>
        /// Mã khu vực
        /// </summary>
        public Guid WardId { get; set; }
        /// <summary>
        /// Tên khu vực
        /// </summary>
        public string WardName { get; set; }
        /// <summary>
        /// Mã huyện
        /// </summary>
        public Guid DistrictId { get; set; }
    }
}
