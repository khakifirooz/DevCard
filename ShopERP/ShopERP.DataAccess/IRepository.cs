using System.Linq.Expressions;

namespace ShopERP.DataAccess
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// دریافت همه رکوردها
        /// </summary>
        List<T> GetAll();

        /// <summary>
        /// دریافت رکوردها با شرط (فیلتر)
        /// مثال: GetByCondition(p => p.Price > 100)
        /// </summary>
        List<T> GetByCondition(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// دریافت یک رکورد با ID
        /// </summary>
        T GetById(int id);

        /// <summary>
        /// اضافه کردن رکورد جدید
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// ویرایش رکورد موجود
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// حذف رکورد با ID
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// ذخیره تغییرات در دیتابیس
        /// </summary>
        void Save();

        /// <summary>
        /// شمارش تعداد رکوردها
        /// </summary>
        int Count();
    }
}
