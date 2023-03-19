namespace HW02.Model;

public class Product : Category
{
    public int CategoryId { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, int categoryId, double price) : base(id, name)
    {
        CategoryId = categoryId;
        Price = price;
    }
}