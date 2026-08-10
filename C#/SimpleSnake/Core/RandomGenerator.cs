using SimpleSnake.Core.Contracts;

namespace SimpleSnake.Core;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random random;

    public RandomGenerator()
    {
        random = new();
    }

    public int NextNumber(int min = 0, int max = int.MaxValue)
    {
        return random.Next(min, max);
    }
}
