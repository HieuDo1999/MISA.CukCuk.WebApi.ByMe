using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IUnitOfWork
    {
        

        ICountryRepository Country { get; }
        IProvinceRepository Province { get; }

        IDistrictRepository DistrictRepository { get; }
    }
}
