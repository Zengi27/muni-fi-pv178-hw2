using System.Text;
using HW02.Model;
using HW02.Repository;

namespace HW02.Service;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;
    private readonly ProductRepository _productRepository;
    
    public CategoryService(CategoryRepository categoryRepository, ProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public Category AddCategory(string name)
    {
        return _categoryRepository.AddCategory(name);
    }

    public Category DeleteCategory(int categoryId)
    {
        var products = _productRepository.ListProducts().FindAll(p => p.CategoryId == categoryId);

        foreach (var product in products)
        {
            _productRepository.DeleteProduct(product.Id);
        }
        
        return _categoryRepository.DeleteCategory(categoryId);
    }

    public string ListCategories()
    {
        List<Category> categories = _categoryRepository.ListCategories();
        
        string header = $"{"Id",-3} | {"Name",-18}\n";
        string line = new string('-', header.Length);
        string body = "";
        
        foreach (var category in categories)
        {
            body += "\n";
            body += $"{category.Id,-3} | {category.Name, -18}";
        }
        
        string output = header + line + body;

        return output;
    }
}