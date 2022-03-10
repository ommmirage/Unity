using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem jetParticles;
    [SerializeField] ParticleSystem leftTrusterParticles;
    [SerializeField] ParticleSystem rightTrusterParticles;

    bool isTransitioning = false;

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) { return; }

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

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
