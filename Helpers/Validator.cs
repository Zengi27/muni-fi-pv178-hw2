namespace HW02.Helpers;

public static class Validator
{
    public static void ListCommand(string[] command)
    {
        CheckNumberOfArgument(command, 0);
    }

    public static void DeleteCommand(string[] command, out int id)
    {
        CheckNumberOfArgument(command, 1);
        id = CheckInt(command[1]);
    }
    
    public static void AddCategory(string[] command, out string name)
    {
        CheckNumberOfArgument(command, 1);
        name = CheckString(command[1]);
    }

    public static void AddProduct(string[] command, out string name, out int categoryId, out double price)
    {
        CheckNumberOfArgument(command, 3);
        name = CheckString(command[1]);
        categoryId = CheckInt(command[2]);
        price = CheckDouble(command[3]);
    }

    public static void GetProductsByCategory(string[] command, out int categoryId)
    {
        CheckNumberOfArgument(command, 1);
        categoryId = CheckInt(command[1]);
    }
    

    private static void CheckNumberOfArgument(string[] command, int requiredNumber)
    {
        if ((command.Length - 1) != requiredNumber)
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