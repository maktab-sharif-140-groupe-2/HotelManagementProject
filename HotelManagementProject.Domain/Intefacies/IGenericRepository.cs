using HotelManagementProject.Domain.Entites;
using System.Linq.Expressions;

namespace HotelManagementProject.Domain.Intefacies;

public interface IGenericRepository<T> where T : BaseEntity
{
    /// <summary>
    /// دریافت همه موجودیت ها 
    /// </summary>
    /// <returns></returns>
    Task<List<TResult>> QueryAsync<TResult>(Expression<Func<T, TResult>> selector, bool tracking = false);
    /// <summary>
    ///  بررسی موجودن بودن یک شرط
    /// </summary>
    /// <param name="selector"></param>
    /// <param name="tracking"></param>
    /// <returns></returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> selector, bool tracking = false);


    /// <summary>
    /// دریافت یک موجدیت با ایدی 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id, bool tracking = false);

    /// <summary>
    /// اضافه کردن موجودیت 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> AddAsync(T entity);

    /// <summary>
    /// اپدیت موجودیت
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    /// حذف نرم موجودیت 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> SoftDeleteAsync(Guid id);
}
