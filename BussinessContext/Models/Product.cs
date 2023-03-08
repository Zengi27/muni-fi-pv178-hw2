namespace HW02.BussinessContext.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int Price { get; set; }

    public Product(int id, string name, int categoryId, int price)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Price = price;
    }
}