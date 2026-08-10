using SimpleSnake.Enums;

namespace SimpleSnake.Models;

public class Snake
{
    public Snake(int startX, int startY, int length)
    {
        Direction = Direction.Right;
        Body = new();
        Head = new(startX, startY);

        for (int i = startX - length + 1; i < startX; i++)
        {
            Point tailPoint = new(i, startY);
            Body.Enqueue(tailPoint);
        }
        Body.Enqueue(Head);
    }

    public Point Head { get; private set; }
    public Queue<Point> Body { get; private set; }
    public Direction Direction { get; private set; }

    public Point Move()
    {
        Point removedBodyPart = Body.Dequeue();

        SetNewHead();

        Body.Enqueue(Head);

        return removedBodyPart;
    }

    private void SetNewHead()
    {
        Point directionPoint = GetDirectionPoint();

        int newHeadX = Head.X + directionPoint.X;
        int newHeadY = Head.Y + directionPoint.Y;

        Head = new(newHeadX, newHeadY);
    }

    private Point GetDirectionPoint()
    {
        switch (Direction)
        {
            case Direction.Right:
                return new(2, 0);
            case Direction.Left:
                return new(-2, 0);
            case Direction.Up:
                return new(0, -1);
            case Direction.Down:
                return new(0, 1);
            default:
                throw new InvalidOperationException($"Invalid direction {Direction}!");
        }
    }

    public void ChangeDirection(Direction direction)
    {
        if (Direction == Direction.Left && direction == Direction.Right ||
            Direction == Direction.Right && direction == Direction.Left ||
            Direction == Direction.Up && direction == Direction.Down ||
            Direction == Direction.Down && direction == Direction.Up)
        {
            return;
        }

        Direction = direction;
    }

    public void IncreaseLength()
    {
        SetNewHead();

        Body.Enqueue(Head);
    }
}
