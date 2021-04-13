using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Store: BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        ///  Họ và tên
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại 
        ///
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuê cửa hàng
        /// 
        /// </summary>
        public string StoreTaxCode { get; set; }
        /// <summary>
        /// Mã nước
        /// 
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// Mã tỉnh
        /// </summary>
        public Guid ProvinceId { get; set; }
        /// <summary>
        /// Mã huyện
        /// </summary>
        public Guid DistrictId { get; set; }
        /// <summary>
        /// Mã khu vực
        /// </summary>
        public Guid WardId { get; set; }
        /// <summary>
        /// 
        /// Mã đường
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }


    }



    }
