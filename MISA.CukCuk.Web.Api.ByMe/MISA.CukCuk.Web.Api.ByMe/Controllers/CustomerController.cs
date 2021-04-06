using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA_Cukcuk_WebAPI.Extensions;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_Cukcuk_WebAPI.Controllers
{

    public class CustomerController : BaseEntityController<Customer>
    {
        IUnitOfWork _unitOfWork;
       
        public CustomerController(IUnitOfWork unitOfWork, IBaseService<Customer> baseService):base(baseService)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getAll")]
        public IActionResult GetAllCustomer()
        {
            return Ok(_unitOfWork.Customer.GetEntities());
        }


        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            var storeParam = new
            {
                CustomerId = customerId
            };
            var rowAffect = _dbConnection.Execute("Proc_DeleteCustomer", param: storeParam, commandType: CommandType.StoredProcedure);
            if (rowAffect == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(rowAffect);
            }
        }
        [HttpPut("{customerId}")]
        public IActionResult Put(Customer customer, Guid customerId)
        {
            //check duplicate customer code
            ValidateCustomer.CheckDuplicateCustomerCodeForUpdate(customer, customer.CustomerCode);
          
            customer.CustomerId = customerId;
            var storeName = "Proc_UpdateCustomer";
            var storeParam = customer;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(customer);
            }
        }
        protected override void ValidateData(Customer customer)
        {
            base.ValidateData(customer);
            ValidateCustomer.CheckCustomerCodeEmpty(customer.CustomerCode);

            ValidateCustomer.CheckDuplicateCustomerCodeForCreate(customer.CustomerCode);

        }


    }
}
