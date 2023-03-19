using HW02.Helpers;
using HW02.Model;
using HW02.OutputContext;
using HW02.Service;

namespace HW02.Controller;

public class ProductController
{
    private readonly ProductService _productService;
    public event EventHandler<Log> OperationCompleted; 

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public void AddProduct(string[] args)
    {
        try
        {
            Validator.AddProduct(args, out string name, out int categoryId, out double price);
            Product product = _productService.AddProduct(name, categoryId, price);  

            InvokeSuccessfulOperation(LogType.Add, product);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Add, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void DeleteProduct(string[] args)
    {
        try
        {
            Validator.DeleteCommand(args, out int productId);    
            Product product = _productService.DeleteProduct(productId);
            
            InvokeSuccessfulOperation(LogType.Delete, product);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Delete, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void ListProducts(string[] args)
    {
        try
        {
            Validator.ListCommand(args);
            string output = _productService.ListProducts();

            InvokeSuccessfulOperation(LogType.Get, null);
            OutputPrinter.Print(output);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Get, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void GetProductsByCategory(string[] args)
    {
        try
        {
            Validator.GetProductsByCategory(args, out int categoryId);
            string output = _productService.GetProductsByCategory(categoryId);
            
            InvokeSuccessfulOperation(LogType.Get, null);
            OutputPrinter.Print(output);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Get, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void UnknownCommand()
    {
        OutputPrinter.Print("Command not found");
    }
    
    private void InvokeSuccessfulOperation(LogType logType, Product? product)
    {
        Log log = new Log(logType, EntityType.Product, OperationResultType.Success, product, "");
        
        OperationCompleted?.Invoke(this, log);
    }

    private void InvokeFailedOperation(LogType logType, string message)
    {
        Log log = new Log(logType, EntityType.Product, OperationResultType.Failure, null, message);

        OperationCompleted?.Invoke(this, log);
    }
}