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

    public void AddCategory(string[] command)
    {
        try
        {
            Validator.AddCategory(command, out string name);
            Category category = _categoryService.AddCategory(name);
            
            InvokeSuccessfulOperation(LogType.Add, category.Id, category.Name);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Add, e.Message);
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteCategory(string[] command)
    {
        try
        {
            Validator.DeleteCommand(command, out int categoryId);
            Category category = _categoryService.DeleteCategory(categoryId);
            
            InvokeSuccessfulOperation(LogType.Delete, category.Id, category.Name);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Delete, e.Message);
            Console.WriteLine(e.Message);
        }
    }

    public void ListCategories(string[] command)
    {
        try
        {
            Validator.ListCommand(command);                    
            string output = _categoryService.ListCategory();
            
            InvokeSuccessfulOperation(LogType.Get, null, null);
            Console.WriteLine(output);
        }
        catch (Exception e)
        {
            InvokeFailedOperation(LogType.Get, e.Message);
            Console.WriteLine(e.Message);
        }
    }
    
    private void InvokeSuccessfulOperation(LogType logType, int? categoryId, string? categoryName)
    {
        Log log = new Log()
        {
            Timestamp = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss"),
            LogType = logType,
            EntityType = EntityType.Category,
            OperationResultType = OperationResultType.Success,
            EntityId = categoryId,
            EntityName = categoryName,
        };

        OperationCompleted?.Invoke(this, log);
    }
    
    private void InvokeFailedOperation(LogType logType, string message)
    {
        Log log = new Log()
        {
            Timestamp = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss"),
            LogType = logType,
            OperationResultType = OperationResultType.Failure,
            Message = message
        };
        
        OperationCompleted?.Invoke(this, log);
    }
}