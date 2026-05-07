using System.Runtime.Versioning;
using System.Text;
using SimpleSnake.Core.Contracts;
using SimpleSnake.Models;

namespace SimpleSnake.Core;

public class ConsoleRenderer : IRenderer
{
    private const char WallSymbol = '\u25A0';
    private const char SnakeSymbol = '\u25CF';
    private const char FoodSymbol = '\uABC1';

    private int maxWidth;
    private int maxHeight;

    [SupportedOSPlatform("windows")]
    public void InitializeField(int maxWidth, int maxHeight)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.CursorVisible = false;
        Console.Clear();

        this.maxWidth = maxWidth;
        this.maxHeight = maxHeight;

        Console.OutputEncoding = Encoding.Unicode;
        Console.SetWindowSize(maxWidth, maxHeight);
    }

    public void RenderWalls(int maxWidth, int maxHeight)
    {
        Console.ForegroundColor = ConsoleColor.White;

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

    public void RenderSnake(Snake snake, Point? toRemove = null)
    {
        if (toRemove != null)
        {
            Console.SetCursorPosition(toRemove.X, toRemove.Y);
            Console.Write(' ');
        }

        foreach (Point point in snake.Body)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(SnakeSymbol);
        }
    }

    public void RenderFood(Point food)
    {
        Console.SetCursorPosition(food.X, food.Y);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(FoodSymbol);
    }

    public void RenderGameOver()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        string message1 = "GAME OVER!";
        string message2 = "Press 'Esc' to exit...";
        string message3 = "Press 'Enter' to restart";

        int x1 = (maxWidth / 2) - (message1.Length / 2);
        int y1 = maxHeight / 2 - 2;

        Console.SetCursorPosition(x1, y1);
        Console.Write(message1);

        int x2 = (maxWidth / 2) - (message2.Length / 2);
        int y2 = y1 + 1;

        Console.SetCursorPosition(x2, y2);
        Console.Write(message2);

        int x3 = (maxWidth / 2) - (message3.Length / 2);
        int y3 = y2 + 1;

        Console.SetCursorPosition(x3, y3);
        Console.Write(message3);
    }
}
