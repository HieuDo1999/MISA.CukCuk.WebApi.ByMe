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

        public IDistrictRepository DistrictRepository { get; }
        public IWardRepository WardRepository { get; }

        public UnitOfWork ( ICountryRepository countryRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository)
        {
            Country = countryRepository;
            Province = provinceRepository;
            DistrictRepository = districtRepository;
            WardRepository = wardRepository;
        }
       
    }
}
