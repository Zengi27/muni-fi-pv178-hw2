using HW02.BussinessContext.Models;
using HW02.BussinessContext.FileDatabase;
using HW02.InputContext;

namespace HW02
{
    public class Program
    {
        public static void Main()
        {
            // TODO: Initialize all clases here, when some dependency needed, insert object through constrcutor
            CommandParser commandParser = new CommandParser();
            
            CategoryDBContext categoryDbContext = new CategoryDBContext();
            List<Category> categories = new List<Category>();
            
           
            Console.WriteLine("input:");

            commandParser.Parse();

            // Category category = new Category(1, "fruit");
            // categories.Add(category);
            //
            // foreach (var cat in categories)
            // {
            //     Console.WriteLine(cat.Name);
            // }
            //
            // categoryDbContext.SaveCategories(categories);
                
        }
    }
}
