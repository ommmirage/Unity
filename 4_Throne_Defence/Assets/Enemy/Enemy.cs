using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 5;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    void Start() 
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        bank.Withdraw(goldPenalty);
    }
}
