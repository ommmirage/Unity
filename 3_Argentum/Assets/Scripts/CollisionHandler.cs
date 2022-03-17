using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log($"Player collided with {other.gameObject.name}");
    }
    private void OnParticleCollision(GameObject other) {
        Debug.Log($"Particles collided with {other.gameObject.name}");
    }
}
