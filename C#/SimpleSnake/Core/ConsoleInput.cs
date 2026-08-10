using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;

namespace SimpleSnake.Core;

public class ConsoleInput : IInput
{
    public Direction? CheckForInput()
    {
        if (!Console.KeyAvailable)
        {
            return null;
        }

        ConsoleKeyInfo keyInfo = Console.ReadKey();

        switch (keyInfo.Key)
        {
            case ConsoleKey.LeftArrow:
                return Direction.Left;
            case ConsoleKey.RightArrow:
                return Direction.Right;
            case ConsoleKey.UpArrow:
                return Direction.Up;
            case ConsoleKey.DownArrow:
                return Direction.Down;
            default:
                return null;
        }
    }

    public bool WaitForRestart()
    {
        while (true)
        {
            var keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
