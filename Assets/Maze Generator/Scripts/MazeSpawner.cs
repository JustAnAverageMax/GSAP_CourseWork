using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private int MazeWidth;
    [SerializeField] private int MazeHeight;


    public Vector3 FloorSize = new Vector3(1, 1, 0);
    
    public GameObject CellPrefab;
    void Start()
    {
        var generator = new MazeGenerator(MazeWidth, MazeHeight);
        var maze = generator.GenerateMaze();
        
        foreach (var c in maze)
        {
            Vector3 cellPosition =
                transform.position + new Vector3(c.X * FloorSize.x, c.Y * FloorSize.y, c.Y * FloorSize.z);
            Cell cell = Instantiate(CellPrefab, cellPosition, Quaternion.identity).GetComponent<Cell>();
            
            cell.SetState(c);
        }
    }
    
}
