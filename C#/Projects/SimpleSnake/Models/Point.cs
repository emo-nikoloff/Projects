namespace SimpleSnake.Models;

public class Point
{
    public Point(int left, int top)
    {
        X = left;
        Y = top;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}
