namespace HW02.InputContext;

public class CommandParser
{
    public void Parse()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string[] commandParts = input.Split(' ');
            var command = commandParts[0];

            if (command == "add-product")
            {
                Console.WriteLine("add");
            }
            else if (command == "exit")
            {
                Console.WriteLine("exit");
                break;
            }    
        }
    }
}