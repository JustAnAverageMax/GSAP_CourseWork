namespace Maze_Generator.Scripts
{
    public static class Extensions
    {
        public static void RemoveExcessElements(this CellDataContainer[,] maze)
        {
            int width = maze.GetLength(0);
            int height = maze.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                maze[i, height - 1].RemoveEveryElement();
            }
            for (int i = 0; i < height; i++)
            {
                maze[width-1, i].RemoveEveryElement();
            }
        }
        
    }
}