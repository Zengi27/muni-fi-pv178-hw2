using HW02.Service;

namespace HW02.Controller;

public class ProductController
{
    private ProductService _productService;
    private CategoryService _categoryService;
    
    public ProductController(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
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