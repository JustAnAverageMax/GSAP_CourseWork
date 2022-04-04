using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    
    public GameObject WallLeft;
    public GameObject WallBottom;
    public GameObject WallRight;
    public GameObject WallUp;
    public GameObject Floor;
    public GameObject blCorner;
    public GameObject brCorner;
    public GameObject ulCorner;
    public GameObject urCorner;

    public void SetState(CellDataContainer container)
    {
        WallLeft.SetActive(container.WallLeftExists);
        WallBottom.SetActive(container.WallBottomExists);
        WallUp.SetActive(container.WallUpExists);
        WallRight.SetActive(container.WallRightExists);
        Floor.SetActive(container.FloorExists);
        blCorner.SetActive(container.BLCornerExists);
        brCorner.SetActive(container.BRCornerExists);
        ulCorner.SetActive(container.ULCornerExists);
        urCorner.SetActive(container.URCornerExists);
    }
}
