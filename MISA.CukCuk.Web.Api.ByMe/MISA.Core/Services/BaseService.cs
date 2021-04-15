using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IUnitOfWork _unitOfWork;
        IBaseRepository<T> _baseRepository;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public T GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public IEnumerable<T> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public int Insert(T entity)
        {
            return _baseRepository.Insert(entity);
        }

        public int Update(T entity, Guid entityId)
        {
            return _baseRepository.Update(entity, entityId);
        }
    }
}
