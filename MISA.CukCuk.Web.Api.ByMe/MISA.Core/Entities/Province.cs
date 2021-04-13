using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
   public class Province
    {
        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public Guid ProviceId { get; set; }

        /// <summary>
        /// Tên tỉnh
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// Mã nước
        /// </summary>
        public Guid CountryId { get; set; }
       
    }
}
