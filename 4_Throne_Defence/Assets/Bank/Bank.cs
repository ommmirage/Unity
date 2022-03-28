using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 100;

    [SerializeField] int balance;
    public int Balance { get { return balance; } }

    void Awake() 
    {
        balance = startingBalance;
    }

    public void Deposit(int amount)
    {
        balance += amount;
    }

    public void Withdraw(int amount)
    {
        balance -= amount;
    }
}
