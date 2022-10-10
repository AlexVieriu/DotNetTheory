namespace MediatorDesignPattern_Problem;

public class Problem
{
    public class Product
    {
        public int Id { get; set; }
    }

    public class Cart
    {
        List<Product> products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }

    public class Catalog
    {
        List<Product> products;
        public List<Product> GetProducts()
        {
            return products;
        }
    }

    public class ProductPage
    {
        private readonly Catalog _catalog;
        private readonly Cart _cart;

        public ProductPage(Catalog catalog, Cart cart)
        {
            _catalog = catalog;
            _cart = cart;
        }

        public void AddToCart(int id)
        {
            var product = _catalog.GetProducts().First(x => x.Id == id);
            _cart.AddProduct(product);
        }

        public void DisplayProducts()
        {
            // set ui elements from catalog
        }
    }
}
