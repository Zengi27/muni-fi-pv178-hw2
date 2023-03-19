using HW02.Model;

namespace HW02.Helpers;

public static class Validator
{
    public static void ListCommand(Command command, string[] args)
    {
        CheckNumberOfArgument(command, args, 0);
    }

    public static void DeleteCommand(Command command, string[] args, out int id)
    {
        CheckNumberOfArgument(command, args, 1);
        id = CheckInt(command, args[0]);
    }
    
    public static void AddCategory(Command command, string[] args, out string name)
    {
        CheckNumberOfArgument(command, args, 1);
        name = CheckString(command, args[0]);
    }

    public static void AddProduct(Command command, string[] args, out string name, out int categoryId, out double price)
    {
        CheckNumberOfArgument(command, args, 3);
        name = CheckString(command, args[0]);
        categoryId = CheckInt(command, args[1]);
        price = CheckDouble(command, args[2]);
    }

    public static void GetProductsByCategory(Command command, string[] args, out int categoryId)
    {
        CheckNumberOfArgument(command, args, 1);
        categoryId = CheckInt(command, args[0]);
    }
    

    private static void CheckNumberOfArgument(Command command, string[] args, int requiredNumber)
    {
        if ((args.Length) != requiredNumber)
        {
            throw new InvalidArgumentException(command);
        }
    }

    private static string CheckString(Command command, string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            throw new InvalidArgumentException(command);
        }

        return arg;
    }

    private static int CheckInt(Command command, string arg)
    {
        if (!int.TryParse(arg, out int intNumber))
        {
            throw new InvalidArgumentException(command);
        }

        return intNumber;
    }

    private static double CheckDouble(Command command, string arg)
    {
        if (!double.TryParse(arg, out double doubleNumber))
        {
            throw new InvalidArgumentException(command);
        }

        return doubleNumber;
    }
}