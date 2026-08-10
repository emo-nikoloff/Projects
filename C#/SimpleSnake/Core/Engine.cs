using SimpleSnake.Core.Contracts;
using SimpleSnake.Models;

namespace SimpleSnake.Core;

public class Engine
{
    private const int InitialGameSpeed = 125;

    private const int PlayAreaWidth = 61;
    private const int PlayAreaHeight = 30;

    private const int SnakeStartHeadX = 7;
    private const int SnakeStartHeadY = 1;
    private const int SnakeLength = 6;

    private IRenderer renderer;
    private IInput input;
    private IRandomGenerator randomGenerator;

    private Snake snake = default!;
    private Point food = default!;

    private int gameSpeed;

    public Engine(IRenderer renderer, IInput input, IRandomGenerator randomGenerator)
    {
        this.renderer = renderer;
        this.input = input;
        this.randomGenerator = randomGenerator;
    }

    public void Run()
    {
        InitializeGame();

        while (true)
        {
            Thread.Sleep(gameSpeed);

            Point removedPoint = snake.Move();

            Enums.Direction? inputDirection = input.CheckForInput();
            if (inputDirection != null)
            {
                snake.ChangeDirection(inputDirection.Value);
            }

            if (!SnakePositionIsValid())
            {
                renderer.RenderGameOver();
                break;
            }

            CheckForFood();

            renderer.RenderSnake(snake, removedPoint);
        }

        if (input.WaitForRestart())
        {
            Run();
        }
    }

    public void InitializeGame()
    {
        gameSpeed = InitialGameSpeed;
        snake = new(SnakeStartHeadX, SnakeStartHeadY, SnakeLength);

        renderer.InitializeField(PlayAreaWidth, PlayAreaHeight);
        renderer.RenderWalls(PlayAreaWidth, PlayAreaHeight);
        renderer.RenderSnake(snake);

        GenerateNewFood();
    }

    private bool SnakePositionIsValid()
    {
        int countHeadPoints = 0;

        foreach (Point point in snake.Body)
        {
            if (point.X < 1 ||
                point.X >= PlayAreaWidth ||
                point.Y < 1 ||
                point.Y >= PlayAreaHeight)
            {
                return false;
            }

            Point snakeHead = snake.Head;

            if (point.X == snakeHead.X && point.Y == snakeHead.Y)
            {
                countHeadPoints++;
            }
        }

        if (countHeadPoints > 1)
        {
            return false;
        }

        return true;
    }

    private void GenerateNewFood()
    {
        while (true)
        {
            bool isValidFood = true;

            int foodX = randomGenerator.NextNumber(1, PlayAreaWidth - 1);
            int foodY = randomGenerator.NextNumber(1, PlayAreaHeight - 1);

            if (foodX % 2 == 0)
            {
                foodX++;
            }

            foreach (Point point in snake.Body)
            {
                if (point.X == foodX && point.Y == foodY)
                {
                    isValidFood = false;
                    break;
                }
            }

            if (isValidFood)
            {
                food = new(foodX, foodY);
                break;
            }
        }

        renderer.RenderFood(food);
    }

    private void CheckForFood()
    {
        Point snakeHead = snake.Head;

        if (food.X == snakeHead.X && food.Y == snakeHead.Y)
        {
            snake.IncreaseLength();
            gameSpeed -= 5;
            GenerateNewFood();
        }
    }
}
