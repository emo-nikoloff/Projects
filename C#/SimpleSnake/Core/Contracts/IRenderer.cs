using SimpleSnake.Models;

namespace SimpleSnake.Core.Contracts;

public interface IRenderer
{
    void InitializeField(int maxWidth, int maxHeight);
    void RenderWalls(int maxWidth, int maxHeight);
    void RenderSnake(Snake snake, Point? toRemove = null);
    void RenderFood(Point food);
    void RenderGameOver();
}
