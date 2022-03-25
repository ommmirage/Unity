using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceble;

    void OnMouseDown() 
    {
        if (isPlaceble)
        {
            GameObject tower = Instantiate(towerPrefab, transform);
            isPlaceble = false;
        }
    }
}
