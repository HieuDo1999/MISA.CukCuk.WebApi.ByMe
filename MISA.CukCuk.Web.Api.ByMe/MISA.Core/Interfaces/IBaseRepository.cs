using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của bảng trong database
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: DTHieu(13/4/2021)
        IEnumerable<T> GetEntities();

        /// <summary>
        /// Lấy thông tin của thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>1 thực thể duy nhất có Id tương ứng</returns>
        /// CreatedBy: DTHieu(13/4/2021)
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>số bản ghi thêm mới được vào Db</returns>
        /// CreatedBy: DTHieu(13/4/2021)
        int Insert(T entity);

        /// <summary>
        /// Sửa thông tin của đối tượng
        /// </summary>
        /// <param name="entity">Thực thể đã được chỉnh sửa</param>
        /// <param name="entityId">ID của thực thể</param>
        /// <returns>Số bản ghi đã update được trong Db</returns>
        /// CreatedBy: DTHieu(13/4/2021)
        int Update(T entity, Guid entityId);

        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns>Số bản ghi đã xóa được trong Db</returns>
        /// CreatedBy: DTHieu(13/4/2021)
        int Delete(Guid entityId);

       
    }
}
