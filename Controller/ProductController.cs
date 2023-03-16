using System.Diagnostics.Tracing;
using HW02.BussinessContext.Models;
using HW02.Model;
using HW02.Service;

namespace HW02.Controller;

public class ProductController
{
    private ProductService _productService;
    private CategoryService _categoryService;
    public event EventHandler<Log> OperationCompleted; 

    public ProductController(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public void AddProduct(string name, int categoryId, double price)
    {
        _productService.AddProduct(name, categoryId, price); 
        InvokeSuccessfulOperation();
    }

    public void DeleteProduct(int productId)
    {
        _productService.DeleteProduct(productId);
    }

    public void ListProducts()
    {
        string output = _productService.ListProducts();
        
        Console.WriteLine(output);
    }

    public void GetProductsByCategory(int categoryId)
    {
        string output = _productService.GetProductsByCategory(categoryId);
        
        Console.WriteLine(output);
    }

    public void UnknownCommand()
    {
        Console.WriteLine("Command not found");
    }
    
    private void InvokeSuccessfulOperation()
    {
        OperationCompleted?.Invoke(this, new Log()
        {
            Timestamp = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss")
        });
    }

    private void InvokeFailedOperation()
    {
        OperationCompleted?.Invoke(this, new Log()
        {
            
        });
    }
}