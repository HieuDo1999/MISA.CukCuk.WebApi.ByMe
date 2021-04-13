using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Country
    {
        /// <summary>
        /// Mã nước
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// Tên nước
        /// </summary>
        public string CountryName { get; set; }
       
    }
}
