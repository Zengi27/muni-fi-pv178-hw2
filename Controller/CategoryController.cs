using HW02.BussinessContext.Models;
using HW02.Helpers;
using HW02.Model;
using HW02.Service;

namespace HW02.Controller;

public class CategoryController
{
    private CategoryService _categoryService;
    public event EventHandler<Log> OperationCompleted; 
    
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public void AddCategory(string[] args)
    {
        try
        {
            Validator.AddCategory(args, out string name);
            Category category = _categoryService.AddCategory(name);
            
            InvokeSuccessfulOperation(LogType.Add, category);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Add, e.Message);
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteCategory(string[] args)
    {
        try
        {
            Validator.DeleteCommand(args, out int categoryId);
            Category category = _categoryService.DeleteCategory(categoryId);
            
            InvokeSuccessfulOperation(LogType.Delete, category);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Delete, e.Message);
            Console.WriteLine(e.Message);
        }
    }

    public void ListCategories(string[] args)
    {
        try
        {
            Validator.ListCommand(args);                    
            string output = _categoryService.ListCategory();
            
            InvokeSuccessfulOperation(LogType.Get, null);
            Console.WriteLine(output);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Get, e.Message);
            Console.WriteLine(e.Message);
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