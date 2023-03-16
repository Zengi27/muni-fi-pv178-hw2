using HW02.Controller;
using HW02.Helpers;

namespace HW02.InputContext;

public class CommandParser
{
    private CategoryController _categoryController;
    private ProductController _productController;

    public CommandParser(CategoryController categoryController, ProductController productController)
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
            var commandName = command[0];

            if (commandName == "list-categories")
            {
                try
                {
                    Validator.ListCommand(command);                    
                    _categoryController.ListCategories();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (commandName == "add-category")
            {
                try
                {
                    Validator.AddCategory(command, out string name);
                    _categoryController.AddCategory(name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (commandName == "delete-category")
            {
                try
                {
                    Validator.DeleteCommand(command, out int categoryId);
                    _categoryController.DeleteCategory(categoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (commandName == "add-product")
            {
                try
                {
                    Validator.AddProduct(command, out string name, out int categoryId, out double price);
                    _productController.AddProduct(name, categoryId, price);   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (commandName == "delete-product")
            {
                try
                {
                    Validator.DeleteCommand(command, out int productId);    
                    _productController.DeleteProduct(productId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (commandName == "list-products")
            {
                try
                {
                    Validator.ListCommand(command);
                    _productController.ListProducts();   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (commandName == "get-products-by-category")
            {
                try
                {
                    Validator.GetProductsByCategory(command, out int categoryId);
                    _productController.GetProductsByCategory(categoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                _productController.UnknownCommand();
            }
        }
    }
}