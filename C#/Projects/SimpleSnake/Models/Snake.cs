using SimpleSnake.Enums;

namespace SimpleSnake.Models;

public class Snake
{
    public Snake(int startLeft, int startTop, int length)
    {
        Direction = Direction.Right;
        Body = new();
        Head = new(startLeft, startTop);

        for (int i = startLeft - length + 1; i < startLeft; i++)
        {
            Point tailPoint = new(i, startTop);
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

        Point directionPoint = GetDirectionPoint();

        int newHeadLeft = Head.Left + directionPoint.Left;
        int newHeadTop = Head.Top + directionPoint.Top;

        Head = new(newHeadLeft, newHeadTop);

        Body.Enqueue(Head);

        return removedBodyPart;
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
        Direction = direction;
    }
}
