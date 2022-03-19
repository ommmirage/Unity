using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScoreBoard scoreBoard;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int maxHp = 8;

    int hp;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        hp = Random.Range(1, maxHp);
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(other.transform.position);
        if (hp < 1)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    void ProcessHit(Vector3 hitPosition)
    {
        hp--;
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        vfx.transform.parent = parent;
    }
}
