using EFCore.Domain.ProductAgg;
using EFCore_Application.Contract.Product;

namespace EFCore_Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _ProductRepository;

        public ProductApplication(IProductRepository repository)
        {
            _ProductRepository = repository;
        }

        public void Create(CreateProduct command)
        {
            if(_ProductRepository.Exist(command.Name, command.CategoryId))
                return;

            var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
            _ProductRepository.Create(product);
            _ProductRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _ProductRepository.Get(id);
            if (product == null)
                return;

            product.Delete();
            _ProductRepository.SaveChanges();
        }

        public void Edit(EditProduct command)
        {
            var product = _ProductRepository.Get(command.Id);
            if(product == null)
                return;

            product.Edit(command.Name, command.UnitPrice, command.CategoryId);
            _ProductRepository.SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            return _ProductRepository.GetDetails(id);
        }

        public void Remove(int id)
        {
            var product = _ProductRepository.Get(id);
            if (product == null)
                return;

            product.Delete();
            _ProductRepository.SaveChanges();
        }

        public void ReStore(int id)
        {
            var product = _ProductRepository.Get(id);
            if (product == null)
                return;

            product.ReStore();
            _ProductRepository.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _ProductRepository.Search(searchModel);
        }
    }
}
