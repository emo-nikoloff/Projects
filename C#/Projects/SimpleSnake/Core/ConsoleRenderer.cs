using System.Text;
using SimpleSnake.Core.Contracts;
using SimpleSnake.Models;

namespace SimpleSnake.Core;

public class ConsoleRenderer : IRenderer
{
    private const char WallSymbol = '\u25A0';
    private const char SnakeSymbol = '\u25CF';
    private const char FoodSymbol = '\u00B0';

    private int maxWidth;
    private int maxHeight;

    public void Initialize(int maxWidth, int maxHeight)
    {
        Console.CursorVisible = false;
        Console.Clear();

        this.maxWidth = maxWidth;
        this.maxHeight = maxHeight;

        Console.OutputEncoding = Encoding.Unicode;
        Console.SetWindowSize(maxWidth, maxHeight);
    }

    public void RenderWalls(int maxWidth, int maxHeight)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        // Top wall
        for (int i = 0; i < maxWidth; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write(WallSymbol);
        }

        // Bottom wall
        for (int i = 0; i < maxWidth; i++)
        {
            Console.SetCursorPosition(i, maxHeight - 1);
            Console.Write(WallSymbol);
        }

        // Left wall
        for (int i = 0; i < maxHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(WallSymbol);
        }

        // Right wall
        for (int i = 0; i < maxHeight; i++)
        {
            Console.SetCursorPosition(maxWidth - 1, i);
            Console.Write(WallSymbol);
        }
    }

    public void RenderSnake(Snake snake, Point toRemove = null)
    {
        if (toRemove != null)
        {
            Console.SetCursorPosition(toRemove.Left, toRemove.Top);
            Console.Write(' ');
        }

        foreach (Point point in snake.Body)
        {
            if (point.Left < 1 ||
                point.Left >= maxWidth ||
                point.Top < 1 ||
                point.Top >= maxHeight)
            {
                throw new InvalidOperationException("Snake is outside of the play area!");
            }

            Console.SetCursorPosition(point.Left, point.Top);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(SnakeSymbol);
        }
    }

    public void RenderFood(Point food)
    {
        Console.SetCursorPosition(food.Left, food.Top);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(FoodSymbol);
    }
}
