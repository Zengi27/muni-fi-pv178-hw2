using HW02.BussinessContext;
using HW02.BussinessContext.FileDatabase;

namespace HW02.Repository;

public class ProductRepository
{
    private ProductDBContext _productDbContext;
    private CategoryDBContext _categoryDbContext;

    public ProductRepository(ProductDBContext productDbContext, CategoryDBContext categoryDbContext)
    {
        _productDbContext = productDbContext;
        _categoryDbContext = categoryDbContext;
    }
    
    private void AddProduct(string name, int categoryId, double price)
    {
        throw new NotImplementedException();
    }

    private void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    private void ListProducts()
    {
        throw new NotImplementedException();
    }

    private void GetProductsByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }
}