using Dapper;
using MISA.Core.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    class ValidateCustomer
    {
        /// <summary>
        /// Check mã khách hàng có nhập hay không?
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// CreatedBy: NVMANH
        public static void CheckCustomerCodeEmpty(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                throw new ValidateExceptions("Mã khách hàng không được phép để trống!");
            }
        }

        public static void CheckDuplicateCustomerCodeForCreate(string customerCode)
        {
            string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02";
            IDbConnection _dbConnection = new MySqlConnection(_connectionString);
            // Validate dữ liệu:
            // - check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            var sqlCheckDuplicateCustomerCode = "Select CustomerCode from Customer Where CustomerCode=@CustomerCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", customerCode);
            var isExitsCustomerCode = _dbConnection.Query(sqlCheckDuplicateCustomerCode, dynamicParameters);
            if (isExitsCustomerCode.Count() > 0)
            {

                throw new ValidateExceptions("Mã khách hàng trung!");

            }
        }
        public static void CheckDuplicateCustomerCodeForUpdate(Customer customer, string customerCode)
        {
            string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02";
            IDbConnection _dbConnection = new MySqlConnection(_connectionString);
            // Validate dữ liệu:
            // - check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            var sqlCheckDuplicateCustomerCode = $"Select CustomerCode from Customer Where CustomerCode=@CustomerCode AND CustomerId <> '{customer.CustomerId}'";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", customerCode);
            var isExitsCustomerCode = _dbConnection.Query(sqlCheckDuplicateCustomerCode, dynamicParameters);
            if (isExitsCustomerCode.Count() > 0)
            {

                throw new ValidateExceptions("Mã khách hàng trung!");

            }
        }
    }
}
