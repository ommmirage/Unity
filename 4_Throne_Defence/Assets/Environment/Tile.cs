using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceble;   
    public bool IsPlaceble { get { return isPlaceble; } }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
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
        if (gridManager.GetNode(coordinates).isWalkable && 
            !pathfinder.WillBlockPath(coordinates) &&
            (coordinates != pathfinder.StartCoordinates) &&
            (coordinates != pathfinder.DestinationCoordinates))
        {
            bool isSuccessful = tower.CreateTower(tower, transform);
            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }

}
