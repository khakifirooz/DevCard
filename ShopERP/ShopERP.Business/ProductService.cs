using ShopERP.DataAccess;
using ShopERP.Models;

namespace ShopERP.Business
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService()
        {
            _productRepo = new Repository<Product>();
        }

        /// <summary>
        /// دریافت همه محصولات فعال
        /// </summary>
        public List<Product> GetAllActiveProducts()
        {
            return _productRepo.GetByCondition(p => p.IsActive == true);
        }

        /// <summary>
        /// دریافت همه محصولات (فعال و غیرفعال)
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        /// <summary>
        /// دریافت محصول با ID
        /// </summary>
        public Product GetProductById(int id)
        {
            return _productRepo.GetById(id);
        }

        /// <summary>
        /// اضافه کردن محصول جدید
        /// </summary>
        public (bool Success, string Message) AddProduct(string name, string code, decimal price, int stock)
        {
            try
            {
                // اعتبارسنجی ورودی
                if (string.IsNullOrWhiteSpace(name))
                    return (false, "نام محصول نمی‌تواند خالی باشد!");

                if (string.IsNullOrWhiteSpace(code))
                    return (false, "کد محصول نمی‌تواند خالی باشد!");

                if (price <= 0)
                    return (false, "قیمت باید بزرگتر از صفر باشد!");

                if (stock < 0)
                    return (false, "موجودی نمی‌تواند منفی باشد!");

                // بررسی تکراری نبودن کد
                var existing = _productRepo.GetByCondition(p => p.Code == code);
                if (existing.Any())
                    return (false, "کد محصول تکراری است!");

                // ایجاد محصول جدید
                var product = new Product
                {
                    Name = name,
                    Code = code,
                    Price = price,
                    Stock = stock,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                _productRepo.Add(product);
                _productRepo.Save();

                return (true, "محصول با موفقیت اضافه شد.");
            }
            catch (Exception ex)
            {
                return (false, $"خطا: {ex.Message}");
            }
        }

        /// <summary>
        /// ویرایش محصول
        /// </summary>
        public (bool Success, string Message) UpdateProduct(int id, string name, decimal price, int stock, bool isActive)
        {
            try
            {
                var product = _productRepo.GetById(id);
                if (product == null)
                    return (false, "محصول یافت نشد!");

                // اعتبارسنجی
                if (string.IsNullOrWhiteSpace(name))
                    return (false, "نام محصول نمی‌تواند خالی باشد!");

                if (price <= 0)
                    return (false, "قیمت باید بزرگتر از صفر باشد!");

                if (stock < 0)
                    return (false, "موجودی نمی‌تواند منفی باشد!");

                // به‌روزرسانی
                product.Name = name;
                product.Price = price;
                product.Stock = stock;
                product.IsActive = isActive;

                _productRepo.Update(product);
                _productRepo.Save();

                return (true, "محصول با موفقیت ویرایش شد.");
            }
            catch (Exception ex)
            {
                return (false, $"خطا: {ex.Message}");
            }
        }

        /// <summary>
        /// حذف محصول (غیرفعال کردن)
        /// </summary>
        public (bool Success, string Message) DeleteProduct(int id)
        {
            try
            {
                var product = _productRepo.GetById(id);
                if (product == null)
                    return (false, "محصول یافت نشد!");

                // به جای حذف فیزیکی، غیرفعال می‌کنیم
                product.IsActive = false;
                _productRepo.Update(product);
                _productRepo.Save();

                return (true, "محصول با موفقیت حذف شد.");
            }
            catch (Exception ex)
            {
                return (false, $"خطا: {ex.Message}");
            }
        }

        /// <summary>
        /// کاهش موجودی (هنگام فروش)
        /// </summary>
        public bool ReduceStock(int productId, int quantity)
        {
            try
            {
                var product = _productRepo.GetById(productId);
                if (product == null || product.Stock < quantity)
                    return false;

                product.Stock -= quantity;
                _productRepo.Update(product);
                _productRepo.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// افزایش موجودی (هنگام برگشت کالا)
        /// </summary>
        public bool IncreaseStock(int productId, int quantity)
        {
            try
            {
                var product = _productRepo.GetById(productId);
                if (product == null)
                    return false;

                product.Stock += quantity;
                _productRepo.Update(product);
                _productRepo.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// جستجوی محصولات
        /// </summary>
        public List<Product> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllActiveProducts();

            keyword = keyword.ToLower();
            return _productRepo.GetByCondition(p =>
                (p.Name.ToLower().Contains(keyword) || p.Code.ToLower().Contains(keyword))
                && p.IsActive == true
            );
        }

        /// <summary>
        /// دریافت محصولات کم‌موجود (موجودی کمتر از حد مشخص)
        /// </summary>
        public List<Product> GetLowStockProducts(int threshold = 10)
        {
            return _productRepo.GetByCondition(p => p.Stock < threshold && p.IsActive == true);
        }
    }
}
