using SimpleSnake.Core.Contracts;
using SimpleSnake.Models;

namespace SimpleSnake.Core;

public class Engine
{
    private const int InitialGameSpeed = 125;

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
        snake = new(SnakeStartHeadLeft, SnakeStartHeadTop, SnakeLength);

        renderer.Initialize(PlayAreaWidth, PlayAreaHeight);
        renderer.RenderWalls(PlayAreaWidth, PlayAreaHeight);
        renderer.RenderSnake(snake);

        GenerateNewFood();
    }

    private bool SnakePositionIsValid()
    {
        int countHeadPoints = 0;

        foreach (Point point in snake.Body)
        {
            if (point.Left < 1 ||
                point.Left >= PlayAreaWidth ||
                point.Top < 1 ||
                point.Top >= PlayAreaHeight)
            {
                return false;
            }

            Point snakeHead = snake.Head;

            if (point.Left == snakeHead.Left && point.Top == snakeHead.Top)
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

        renderer.RenderFood(avaiableFood);
    }

    private void CheckForFood()
    {
        Point snakeHead = snake.Head;

        if (avaiableFood.Left == snakeHead.Left && avaiableFood.Top == snakeHead.Top)
        {
            snake.IncreaseLength();
            gameSpeed -= 5;
            GenerateNewFood();
        }
    }
}
