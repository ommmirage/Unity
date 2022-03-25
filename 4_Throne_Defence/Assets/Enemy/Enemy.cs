using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp = 5;
    int hp;

    void Start()
    {
        hp = maxHp;
    }

    void OnParticleCollision(GameObject other) 
    {
        hp--;
        Debug.Log(hp);
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}