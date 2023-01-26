using CatalogService.DataBase;

namespace CatalogService.Service
{

    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            var res = _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == Id);
            if (product == null)
            {
                return false;
            }
            var pro = _context.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var toUpdate = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (toUpdate == null) { return null; }
            var produc = _context.Products.Update(toUpdate);
            _context.SaveChanges();
            return product;
        }
    }
}
