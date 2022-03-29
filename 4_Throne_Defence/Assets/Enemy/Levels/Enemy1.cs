using UnityEngine;

public class Enemy1 : Enemy
{
    [SerializeField] int goldReward = 5;
    [SerializeField] int goldPenalty = 25;
    [SerializeField] int maxHp = 5;

    int hp;

    void OnEnable()
    {
        hp = maxHp;
    }

    void OnParticleCollision(GameObject other) 
    {
        hp--;
        if (hp < 1)
        {
            gameObject.SetActive(false);
            RewardGold();
        }
    }

    public void StealGold()
    {
        base.StealGold(goldPenalty);
    }

    public void RewardGold()
    {
        base.RewardGold(goldReward);
    }
}
