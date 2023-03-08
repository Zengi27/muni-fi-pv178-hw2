using HW02.Repository;

namespace HW02.Service;

public class CategoryService
{
    private CategoryRepository _categoryRepository;
    
    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    private void AddCategory(string name)
    {
        throw new NotImplementedException();
    }

    private void DeleteCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    private void ListCategory()
    {
        throw new NotImplementedException();
    }
}