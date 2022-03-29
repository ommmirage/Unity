using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceble;   
    public bool IsPlaceble { get { return isPlaceble; } }

    void OnMouseDown() 
    {
        if (isPlaceble)
        {
            bool isPlaced = tower.CreateTower(tower, transform);
            isPlaceble = !isPlaced;
        }
    }

}
