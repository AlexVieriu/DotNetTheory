namespace MediatorDesignPattern_Solution;

public class Solution
{
    public class Product
    {
        public int Id { get; set; }
    }

    public class ShopContext
    {
        Cart cart;
        Catalog catalog;
        ProductPage page;

        public ShopContext(Cart cart, Catalog catalog, ProductPage page)
        {
            this.cart = cart;
            this.catalog = catalog;
            this.page = page;

            this.page.DisplayProducts(catalog.GetProducts());
        }

        public void AddToCart(int id)
        {
            cart.AddProduct(catalog.GetProducts().First(x => x.Id == id));
        }
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
        ShopContext context;
        public ProductPage(ShopContext context) => this.context = context;

        public void AddToCart(int id) => context.AddToCart(id);

        public void DisplayProducts(List<Product> products) { }
    }
}