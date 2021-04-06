using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork, IBaseRepository<Customer> baseRepository) : base(unitOfWork,baseRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _unitOfWork.Customer.GetEntities();

        }

    }
}
