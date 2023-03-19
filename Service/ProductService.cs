using HW02.BussinessContext.Models;
using HW02.Repository;

namespace HW02.Service;

public class ProductService
{
    private ProductRepository _productRepository;
    private CategoryRepository _categoryRepository;
    
    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
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
        var header = $"{"Id",-3}" + " | " + $"{"Name",-10}" + " | " + $"{"CategoryId",-10}" + " | " + "Price\n";
        var line = new string('-', header.Length) + "\n";
        var body = "";
        
        foreach (var product in products)
        {
            body += $"{product.Id,-3}" + " | " + $"{product.Name,-10}" + " | " + $"{product.CategoryId,-10}" + " | " + $"{product.Price}\n";
        }
        
        var output = header + line + body;

        return output;
    }
}