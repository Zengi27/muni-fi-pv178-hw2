namespace HW02.Models;

public class Product
{
    public int Id;
    public string Name;
    public int CategoryId;
    public int Price;

    public Product(int id, string name, int categoryId, int price)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Price = price;
    }
}