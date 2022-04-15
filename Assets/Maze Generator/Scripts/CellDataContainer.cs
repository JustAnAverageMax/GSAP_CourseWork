using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDataContainer
{
    public int X;
    public int Y;

    public bool WallLeftExists = true;
    public bool WallBottomExists = true;
    public bool FloorExists = true;
    
    
    public bool BLCornerExists = true;
    public bool Visited = false;

    public CellDataContainer(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    
}
