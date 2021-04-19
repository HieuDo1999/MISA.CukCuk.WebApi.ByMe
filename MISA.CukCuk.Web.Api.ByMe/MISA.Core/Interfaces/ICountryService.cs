using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// Interface của country server  kế thừa ibase service
    /// </summary>
    /// created by: DTHIEU(13/4/2021)
    public interface ICountryService:IBaseService<Country>
    {
        IEnumerable<Country> GetAllCountry();
    }
}
