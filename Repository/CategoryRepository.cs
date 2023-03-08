using HW02.BussinessContext.FileDatabase;

namespace HW02.Repository;

public class CategoryRepository
{
    private CategoryDBContext _categoryDbContext;

    public CategoryRepository(CategoryDBContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
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