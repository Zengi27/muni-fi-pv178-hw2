using HW02.Service;

namespace HW02.Controller;

public class CategoryController
{
    private CategoryService _categoryService;
    
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    private void AddCategory(string name)
    {
        throw new NotImplementedException();
    }

    private void DeleteCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    private void ListCategories()
    {
        throw new NotImplementedException();
    }
}