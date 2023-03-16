using HW02.BussinessContext.Models;
using HW02.Service;

namespace HW02.Controller;

public class CategoryController
{
    private CategoryService _categoryService;
    
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public void AddCategory(string name)
    {
        _categoryService.AddCategory(name);
    }

    public void DeleteCategory(int categoryId)
    {
        _categoryService.DeleteCategory(categoryId);
    }

    public void ListCategories()
    {
        string output = _categoryService.ListCategory();
        
        Console.WriteLine(output);
    }
}