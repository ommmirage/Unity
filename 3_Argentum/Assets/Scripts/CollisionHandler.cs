using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem explosionParticles;

    private void OnCollisionEnter(Collision other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        explosionParticles.Play();
        Invoke("ReloadLevel", loadDelay);
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log($"Particles collided with {other.gameObject.name}");
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
