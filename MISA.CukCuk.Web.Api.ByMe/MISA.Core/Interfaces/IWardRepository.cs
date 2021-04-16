using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IWardRepository:IBaseRepository<Ward>
    {
        public IEnumerable<Ward> GetWardWithDistrict(Guid wardId);
    }
}
