using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem explosionParticles;

    private void Start() 
    {
        playerController = GetComponent<PlayerController>();    
    }

    private void OnCollisionEnter(Collision other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        playerController.SetGunsActive(false);
        explosionParticles.Play();
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
