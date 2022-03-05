using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody rigidBody;
    Renderer renderer;
    [SerializeField] float timeToFall = 3f;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        rigidBody.useGravity = false;
        renderer.enabled = false;
    }

    void Update()
    {
        if (Time.time > timeToFall)
        {
            rigidBody.useGravity = true;
            renderer.enabled = true;
        }
    }
}
