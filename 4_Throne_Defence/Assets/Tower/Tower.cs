using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 10;

    public bool CreateTower(Tower towerPrefab, Transform transform)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank.Balance >= cost)
        {
            bank.Withdraw(cost);
            Instantiate(towerPrefab.gameObject, transform);
            return true;
        }
        return false;
    }
}
