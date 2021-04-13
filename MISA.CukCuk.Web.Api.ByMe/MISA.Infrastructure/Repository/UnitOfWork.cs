using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
       
        public ICountryRepository Country
        {
            get;
        }

        public IProvinceRepository Province
        {
            get;
        }

        public UnitOfWork ( ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            Country = countryRepository;
            Province = provinceRepository;
        }
       
    }
}
