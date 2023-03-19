using HW02.AnalyticalDataContext;
using HW02.AnalyticalDataContext.DB;
using HW02.BussinessContext;
using HW02.BussinessContext.FileDatabase;
using HW02.Controller;
using HW02.Helpers;
using HW02.InputContext;
using HW02.LoggerContext.DB;
using HW02.Model;
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
            ProductService productService = new ProductService(productRepository);
            
            CategoryController categoryController = new CategoryController(categoryService);
            ProductController productController = new ProductController(productService);

            LoggerDBContext loggerDbContext = new LoggerDBContext();
            LoggerListener loggerListener = new LoggerListener(loggerDbContext);

            AnalyticalDBContext analyticalDbContext = new AnalyticalDBContext();
            AnalyticalDataListener analyticalDataListener = new AnalyticalDataListener(analyticalDbContext);
            
            productController.OperationCompleted += loggerListener.OnOperationCompleted;
            categoryController.OperationCompleted += loggerListener.OnOperationCompleted;

            categoryController.OperationCompleted += analyticalDataListener.OnOperationCompleted;
            productController.OperationCompleted += analyticalDataListener.OnOperationCompleted;
            
            Seeder seeder = new Seeder(categoryController, productController);
            seeder.Seed();

            InputParser inputParser = new InputParser(categoryController, productController);
            inputParser.Parse();
        }
    }
}
