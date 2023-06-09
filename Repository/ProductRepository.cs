using HW02.BussinessContext;
using HW02.Helpers;
using HW02.Model;

namespace HW02.Repository;

public class ProductRepository
{
    private readonly ProductDBContext _productDbContext;
    private readonly IdGenerator _idGenerator;
    
    public ProductRepository(ProductDBContext productDbContext, IdGenerator idGenerator)
    {
        _productDbContext = productDbContext;
        _idGenerator = idGenerator;
    }
    
    public Product AddProduct(string name, int categoryId, double price)
    {
        List<Product> products = _productDbContext.ReadProducts();
        Product product = new Product(_idGenerator.GetNextId(), name, categoryId, price);
        
        products.Add(product);
        _productDbContext.SaveProducts(products);

        return product;
    }

    public Product DeleteProduct(int productId)
    {
        List<Product> products = _productDbContext.ReadProducts();
        Product product = products.Find(p => p.Id == productId);
        
        if (product == null)
        {
            throw new IdNotFoundException(productId, EntityType.Product);
        }
        products.Remove(product);
        _productDbContext.SaveProducts(products);

        return product;
    }

    public List<Product> ListProducts()
    {
        return _productDbContext.ReadProducts();
    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        List<Product> products = _productDbContext.ReadProducts().FindAll(p => p.CategoryId == categoryId);
        
        return products;
    }
}