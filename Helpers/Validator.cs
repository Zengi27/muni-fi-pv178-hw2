namespace HW02.Helpers;

public static class Validator
{
    public static void ListCommand(string[] args)
    {
        CheckNumberOfArgument(args, 0);
    }

    public static void DeleteCommand(string[] args, out int id)
    {
        CheckNumberOfArgument(args, 1);
        id = CheckInt(args[0]);
    }
    
    public static void AddCategory(string[] args, out string name)
    {
        CheckNumberOfArgument(args, 1);
        name = CheckString(args[0]);
    }

    public static void AddProduct(string[] args, out string name, out int categoryId, out double price)
    {
        CheckNumberOfArgument(args, 3);
        name = CheckString(args[0]);
        categoryId = CheckInt(args[1]);
        price = CheckDouble(args[2]);
    }

    public static void GetProductsByCategory(string[] args, out int categoryId)
    {
        CheckNumberOfArgument(args, 1);
        categoryId = CheckInt(args[0]);
    }
    

    private static void CheckNumberOfArgument(string[] args, int requiredNumber)
    {
        if ((args.Length) != requiredNumber)
        {
            throw new InvalidArgumentException();
        }
    }

    private static string CheckString(string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            throw new InvalidArgumentException();
        }

        return arg;
    }

    private static int CheckInt(string arg)
    {
        if (!int.TryParse(arg, out int intNumber))
        {
            throw new InvalidArgumentException();
        }

        return intNumber;
    }

    private static double CheckDouble(string arg)
    {
        if (!double.TryParse(arg, out double doubleNumber))
        {
            throw new InvalidArgumentException();
        }

        return doubleNumber;
    }
}