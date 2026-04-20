using SimpleSnake.Enums;

namespace SimpleSnake.Core.Contracts;

public interface IInput
{
    Direction? CheckForInput();
}
