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
                maze[i, height - 1].WallLeftExists = false;
                maze[i, height - 1].FloorExists = false;
            }
            for (int i = 0; i < height; i++)
            {
                maze[width - 1, i].WallBottomExists = false;
                maze[width - 1, i].FloorExists = false;
            }
        }
        
    }
}