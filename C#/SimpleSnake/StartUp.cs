using SimpleSnake.Core;
using SimpleSnake.Core.Contracts;

namespace SimpleSnake;

public class StartUp
{
    public static void Main()
    {
        IRenderer consoleRenderer = new ConsoleRenderer();
        IInput consoleInput = new ConsoleInput();
        IRandomGenerator randomGenerator = new RandomGenerator();
        Engine engine = new Engine(consoleRenderer, consoleInput, randomGenerator);

        engine.Run();
    }
}