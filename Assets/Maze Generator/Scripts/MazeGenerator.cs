using System;
using System.Collections;
using System.Collections.Generic;
using Maze_Generator.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator
{
    private int Width;
    private int Height;

    public MazeGenerator(int width, int height)
    {
        Width = width;
        Height = height;
    }


    public CellDataContainer[,] GenerateMaze()
    {
        var maze = new CellDataContainer[Width, Height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new CellDataContainer(x, y);
            }
        }

        maze.RemoveExcessElements();
        BuildMaze(maze);

        return maze;
    }

    private void BuildMaze(CellDataContainer[,] maze)
    {
        var current = maze[0, 0];
        current.Visited = true;
        current.WallBottomExists = false;
        var movesHistory = new Stack<CellDataContainer>();
        do
        {
            var unvisitedNeighbours = GetUnvisitedCellNeighbours(current, maze);
            if (unvisitedNeighbours.Count > 0)
            {
                var nextCell = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWalls(current, nextCell);
                nextCell.Visited = true;
                movesHistory.Push(nextCell);
                current = nextCell;
            }
            else
            {
                current = movesHistory.Pop();
            }
        } while (movesHistory.Count > 0);
    }

    private void RemoveWalls(CellDataContainer first, CellDataContainer second)
    {
        if (first.X == second.X)
        {
            if (first.Y > second.Y)
            {
                first.WallBottomExists = false;
                second.WallUpExists = false;
            }
            else
            {
                second.WallBottomExists = false;
                first.WallUpExists = false;
            }
        }

        if (first.Y == second.Y)
        {
            if (first.X > second.X)
            {
                first.WallLeftExists = false;
                second.WallRightExists = false;
            }
            else
            {
                second.WallLeftExists = false;
                first.WallRightExists = false;
            }
        }
    }


    private List<CellDataContainer> GetUnvisitedCellNeighbours(CellDataContainer cell, CellDataContainer[,] maze)
    {
        var neighbours = new List<CellDataContainer>();
        if (cell.X > 0 && !maze[cell.X - 1, cell.Y].Visited) neighbours.Add(maze[cell.X - 1, cell.Y]);
        if (cell.Y > 0 && !maze[cell.X, cell.Y - 1].Visited) neighbours.Add(maze[cell.X, cell.Y - 1]);
        if (cell.X < Width - 2 && !maze[cell.X + 1, cell.Y].Visited) neighbours.Add(maze[cell.X + 1, cell.Y]);
        if (cell.Y < Height - 2 && !maze[cell.X, cell.Y + 1].Visited) neighbours.Add(maze[cell.X, cell.Y + 1]);
        return neighbours;
    }
}