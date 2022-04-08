using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    
    public GameObject WallLeft;
    public GameObject WallBottom;
    public GameObject Floor;
    public GameObject blCorner;


    public void SetState(CellDataContainer container)
    {
        WallLeft.SetActive(container.WallLeftExists);
        WallBottom.SetActive(container.WallBottomExists);
        Floor.SetActive(container.FloorExists);
        blCorner.SetActive(container.BLCornerExists);
    }
}
