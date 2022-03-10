using UnityEngine;

public class CollisionHandler : Levels
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem jetParticles;
    [SerializeField] ParticleSystem leftTrusterParticles;
    [SerializeField] ParticleSystem rightTrusterParticles;

    bool isTransitioning = false;

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || !Levels.collisionEnabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Respawn":
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        explosionParticles.Play();
        Debug.Log(GetComponent<MeshRenderer>());
        DestroyRocket();
        Invoke("ReloadLevel", 1);
    }

    void DestroyRocket()
    {
        transform.localScale = new Vector3(0, 0, 0);
        jetParticles.Stop();
        leftTrusterParticles.Stop();
        rightTrusterParticles.Stop();
    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        successParticles.Play();
        Invoke("LoadNextLevel", 0.5f);
    }
}
