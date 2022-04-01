using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 10;
    [SerializeField] float bildDelay = 0.2f;

    void Start()
    {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower towerPrefab, Transform transform)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if (bank.Balance >= cost)
        {
            bank.Withdraw(cost);
            Instantiate(towerPrefab.gameObject, transform);
            return true;
        }
        return false;
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(bildDelay);
        }

        yield return new WaitForSeconds(bildDelay);

        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);

    }
}
