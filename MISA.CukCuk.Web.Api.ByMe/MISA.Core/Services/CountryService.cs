using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        IUnitOfWork _unitOfWork;
        public CountryService(IUnitOfWork unitOfWork, IBaseRepository<Country> baseRepository) : base(unitOfWork,baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Country> GetAllCountry()
        {
            return _unitOfWork.Country.GetEntities();
        }

      
    }
}
