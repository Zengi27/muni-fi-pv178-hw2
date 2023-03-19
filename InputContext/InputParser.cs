using HW02.Controller;

namespace HW02.InputContext;

public class InputParser
{
    private readonly CategoryController _categoryController;
    private readonly ProductController _productController;

    public InputParser(CategoryController categoryController, ProductController productController)
    {
        _categoryController = categoryController;
        _productController = productController;
    }

    public void Parse()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string[] command = input.Split(' ');
            string commandName = command[0];
            string[] args = command.Skip(1).ToArray();
            
            if (commandName == "list-categories")
            {
                _categoryController.ListCategories(args);
            }
            else if (commandName == "add-category")
            {
                _categoryController.AddCategory(args);
            }
            else if (commandName == "delete-category")
            {
                _categoryController.DeleteCategory(args);
            }
            else if (commandName == "add-product")
            {
                _productController.AddProduct(args);   
            }
            else if (commandName == "delete-product")
            {
                _productController.DeleteProduct(args);
            }
            else if (commandName == "list-products")
            {
                _productController.ListProducts(args); 
            }
            else if (commandName == "get-products-by-category")
            {
                _productController.GetProductsByCategory(args);
            }
            else
            {
                _productController.UnknownCommand(commandName);
            }
        }
    }
}