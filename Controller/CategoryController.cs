using HW02.Helpers;
using HW02.Model;
using HW02.OutputContext;
using HW02.Service;

namespace HW02.Controller;

public class CategoryController
{
    private readonly CategoryService _categoryService;
    public event EventHandler<Log> OperationCompleted; 
    
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public void AddCategory(string[] args)
    {
        try
        {
            Validator.AddCategory(Command.AddCategory, args, out string name);
            Category category = _categoryService.AddCategory(name);
            
            InvokeSuccessfulOperation(LogType.Add, category);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Add, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void DeleteCategory(string[] args)
    {
        try
        {
            Validator.DeleteCommand(Command.DeleteCategory, args, out int categoryId);
            Category category = _categoryService.DeleteCategory(categoryId);
            
            InvokeSuccessfulOperation(LogType.Delete, category);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Delete, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    public void ListCategories(string[] args)
    {
        try
        {
            Validator.ListCommand(Command.ListCategories, args);                    
            string output = _categoryService.ListCategories();
            
            InvokeSuccessfulOperation(LogType.Get, null);
            OutputPrinter.Print(output);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Get, e.Message);
            OutputPrinter.Print(e.Message);
        }
    }

    private void InvokeSuccessfulOperation(LogType logType, Category? category)
    {
        Log log = new Log(logType, EntityType.Category, OperationResultType.Success, category, "");

        OperationCompleted?.Invoke(this, log);
    }
    
    private void InvokeFailedOperation(LogType logType, string message)
    {
        Log log = new Log(logType, EntityType.Category, OperationResultType.Failure, null, message);

        OperationCompleted?.Invoke(this, log);
    }
}