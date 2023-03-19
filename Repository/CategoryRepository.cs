using HW02.BussinessContext.FileDatabase;
using HW02.Helpers;
using HW02.Model;

namespace HW02.Repository;

public class CategoryRepository
{
    private readonly CategoryDBContext _categoryDbContext;
    private readonly IdGenerator _idGenerator;

    public CategoryRepository(CategoryDBContext categoryDbContext, IdGenerator idGenerator)
    {
        _categoryDbContext = categoryDbContext;
        _idGenerator = idGenerator;
    }
    
    public Category AddCategory(string name)
    {
        List<Category> categories = _categoryDbContext.ReadCategories();
        Category category = new Category(_idGenerator.GetNextId(), name);
        
        categories.Add(category);
        _categoryDbContext.SaveCategories(categories);
        
        return category;
    }

    public Category DeleteCategory(int categoryId)
    {
        List<Category> categories = _categoryDbContext.ReadCategories();

        Category category = categories.Find(c => c.Id == categoryId);

        if (category == null)
        {
            throw new IdNotFoundException(categoryId);
        }
        categories.Remove(category);
        _categoryDbContext.SaveCategories(categories);
        
        return category;
    }

    public List<Category> ListCategory()
    {
        return _categoryDbContext.ReadCategories();
    }
}