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