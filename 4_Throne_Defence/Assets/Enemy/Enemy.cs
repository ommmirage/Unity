using UnityEngine;

public class Enemy : MonoBehaviour
{
    Bank bank;

    void Start() 
    {
        bank = FindObjectOfType<Bank>();
    }

    protected void RewardGold(int goldReward)
    {
        bank.Deposit(goldReward);
    }

    protected void StealGold(int goldPenalty)
    {
        bank.Withdraw(goldPenalty);
    }
}
