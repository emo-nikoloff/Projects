using SimpleSnake.Core.Contracts;
using SimpleSnake.Models;

namespace SimpleSnake.Core;

public class Engine
{
    private const int GameSpeed = 150;

    private const int PlayAreaWidth = 61;
    private const int PlayAreaHeight = 30;

    private const int SnakeStartHeadLeft = 7;
    private const int SnakeStartHeadTop = 1;
    private const int SnakeLength = 6;

    private IRenderer renderer;
    private IInput input;
    private IRandomGenerator randomGenerator;

    private Snake snake;
    private Point avaiableFood;

    public Engine(IRenderer renderer, IInput input, IRandomGenerator randomGenerator)
    {
        this.renderer = renderer;
        this.input = input;
        snake = new(SnakeStartHeadLeft, SnakeStartHeadTop, SnakeLength);
        this.randomGenerator = randomGenerator;
    }

    public void Run()
    {
        InitializeGame();

        while (true)
        {
            Thread.Sleep(GameSpeed);

            Point removedPoint = snake.Move();

            Enums.Direction? inputDirection = input.CheckForInput();
            if (inputDirection != null)
            {
                snake.ChangeDirection(inputDirection.Value);
            }

            renderer.RenderSnake(snake, removedPoint);
        }
    }

    public void InitializeGame()
    {
        renderer.Initialize(PlayAreaWidth, PlayAreaHeight);
        renderer.RenderWalls(PlayAreaWidth, PlayAreaHeight);

        renderer.RenderSnake(snake);
        GenerateNewFood();
        renderer.RenderFood(avaiableFood);
    }

    private void GenerateNewFood()
    {
        while (true)
        {
            bool isValidFood = true;

            int foodLeft = randomGenerator.NextNumber(1, PlayAreaWidth - 1);
            int foodTop = randomGenerator.NextNumber(1, PlayAreaHeight - 1);

            if (foodLeft % 2 == 0)
            {
                foodLeft++;
            }

            foreach (Point point in snake.Body)
            {
                if (point.Left == foodLeft && point.Top == foodTop)
                {
                    isValidFood = false;
                    break;
                }
            }

            if (isValidFood)
            {
                avaiableFood = new(foodLeft, foodTop);
                break;
            }
        }
    }
}
