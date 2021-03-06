using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScoreBoard scoreBoard;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int maxHp = 6;

    int hp;
    GameObject parentGameObject;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        hp = Random.Range(1, maxHp);
        parentGameObject = GameObject.FindWithTag("Spawn At Runtime");
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(transform.position);
        if (hp < 1)
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        scoreBoard.IncreaseScore(scorePerHit * 2);
    }

    void ProcessHit(Vector3 hitPosition)
    {
        hp--;
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
