using HW02.BussinessContext;
using HW02.BussinessContext.Models;
using HW02.BussinessContext.FileDatabase;
using HW02.Controller;
using HW02.Helpers;
using HW02.InputContext;
using HW02.LoggerContext.DB;
using HW02.Repository;
using HW02.Service;

namespace HW02
{
    public class Program
    {
        public static void Main()
        {
            IdGenerator categoryIdGenerator = new IdGenerator();
            IdGenerator productIdGenerator = new IdGenerator();
            
            CategoryDBContext categoryDbContext = new CategoryDBContext();
            ProductDBContext productDbContext = new ProductDBContext(categoryDbContext);
            
            CategoryRepository categoryRepository = new CategoryRepository(categoryDbContext, categoryIdGenerator);
            ProductRepository productRepository = new ProductRepository(productDbContext, productIdGenerator);
            
            CategoryService categoryService = new CategoryService(categoryRepository, productRepository);
            ProductService productService = new ProductService(productRepository, categoryRepository);
            
            CategoryController categoryController = new CategoryController(categoryService);
            ProductController productController = new ProductController(productService, categoryService);

            LoggerDBContext loggerDbContext = new LoggerDBContext();
            LoggerListener loggerListener = new LoggerListener(loggerDbContext);

            productController.OperationCompleted += loggerListener.OnOperationCompleted; 
            
            Seeder seeder = new Seeder(categoryRepository, productRepository);
            
            seeder.Seeding();
            
            CommandParser commandParser = new CommandParser(categoryController, productController);
            commandParser.Parse();
        }
    }
}
