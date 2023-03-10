using HW02.BussinessContext;
using HW02.BussinessContext.FileDatabase;
using HW02.Repository;

namespace HW02.Helpers;

public class Seeder
{
    private CategoryRepository _categoryRepository;
    private ProductRepository _productRepository;

    public Seeder(CategoryRepository categoryRepository, ProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public void Seeding()
    {
        _categoryRepository.AddCategory("fruit");
        _categoryRepository.AddCategory("vegetables");
        _categoryRepository.AddCategory("animals");

        _productRepository.AddProduct("apple", 1, 35);
        _productRepository.AddProduct("banana", 1, 10);
        _productRepository.AddProduct("carrot", 2, 5);
    }
}