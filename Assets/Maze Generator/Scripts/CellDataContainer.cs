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
    
    public bool WallRightExists = true;
    public bool WallUpExists = true;
    
    public bool BLCornerExists = true;
    public bool BRCornerExists = true;
    public bool ULCornerExists = true;
    public bool URCornerExists = true;
    public bool Visited = false;

    public CellDataContainer(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void RemoveEveryElement()
    {
        WallLeftExists = false;
        WallBottomExists = false;
        FloorExists = false;
        WallRightExists = false;
        WallUpExists = false;
        BLCornerExists = false;
        BRCornerExists = false;
        ULCornerExists = false;
        URCornerExists = false;
       
    }
}
