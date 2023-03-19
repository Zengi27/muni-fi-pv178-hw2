using HW02.Model;
using HW02.Repository;

namespace HW02.Service;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product AddProduct(string name, int categoryId, double price)
    {
        return _productRepository.AddProduct(name, categoryId, price);
    }

    public Product DeleteProduct(int productId)
    {
        return _productRepository.DeleteProduct(productId);
    }

    public string ListProducts()
    {
        List<Product> products = _productRepository.ListProducts();

        return MakeTableOutput(products);
    }

    public string GetProductsByCategory(int categoryId)
    {
        List<Product> products = _productRepository.GetProductsByCategory(categoryId);
        
        return MakeTableOutput(products); 
    }

    private string MakeTableOutput(List<Product> products)
    {
        string header = $"{"Id",-3} | {"Name",-18} | {"CategoryId",-10} | Price\n";
        string line = new string('-', header.Length);
        string body = "";
        
        foreach (var product in products)
        {
            body += "\n";
            body += $"{product.Id,-3} | {product.Name,-18} | {product.CategoryId,-10} | {product.Price}";
        }
        
        string output = header + line + body;

        return output;
    }
}