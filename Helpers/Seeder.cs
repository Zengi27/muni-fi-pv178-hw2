using HW02.Controller;

namespace HW02.Helpers;

public class Seeder
{
    private readonly CategoryController _categoryController;
    private readonly ProductController _productController;

    public Seeder(CategoryController categoryController, ProductController productController)
    {
        _categoryController = categoryController;
        _productController = productController;
    }

    public void Seed()
    {
        _categoryController.AddCategory(new string[] {"fruit"});
        _categoryController.AddCategory(new string[] {"vegetables"});
        _categoryController.AddCategory(new string[] {"animals"});

        _productController.AddProduct(new string[]{"apple", "1", "35"});
        _productController.AddProduct(new string[]{"banana", "1", "10"});
        _productController.AddProduct(new string[]{"carrot", "2", "5"});
    }
}