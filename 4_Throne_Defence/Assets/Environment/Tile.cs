using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceble;   
    public bool IsPlaceble { get { return isPlaceble; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceble)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown() 
    {
        if (isPlaceble)
        {
            bool isPlaced = tower.CreateTower(tower, transform);
            isPlaceble = !isPlaced;
        }
    }

}
