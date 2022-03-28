using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 5;

    Enemy enemy;

    int hp;

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        hp = maxHp;
    }

    void OnParticleCollision(GameObject other) 
    {
        hp--;
        Debug.Log(hp);
        if (hp < 1)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
