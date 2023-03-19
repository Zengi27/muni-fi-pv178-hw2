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
        var products = _productRepository.GetProductsByCategory(categoryId);

        foreach (var product in products)
        {
            _productRepository.DeleteProduct(product.Id);
        }
        
        return _categoryRepository.DeleteCategory(categoryId);
    }

    public string ListCategory()
    {
        List<Category> categories = _categoryRepository.ListCategory();

        string header = "Id | Name\n";
        string line = "------------------\n";
        string body = "";
        
        foreach (var category in categories)
        {
            body += category.Id + "  | " + category.Name + "\n";
        }
        
        string output = header + line + body;

        return output;
    }
}