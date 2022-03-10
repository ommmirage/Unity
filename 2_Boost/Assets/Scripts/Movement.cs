using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 60f;
    [SerializeField] ParticleSystem jetParticles;
    [SerializeField] ParticleSystem leftTrusterParticles;
    [SerializeField] ParticleSystem rightTrusterParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    // Тяга
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartTrhusting();
        }
        else 
        {
            jetParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            leftTrusterParticles.Stop();
            rightTrusterParticles.Stop();
        }
    }

    private void StartTrhusting()
    {
        if (!jetParticles.isPlaying)
        {
            jetParticles.Play();
        }
        rb.AddRelativeForce(0, thrustPower * Time.deltaTime, 0);
    }

    private void RotateLeft()
    {
        Rotate(rotationPower);
        if (!rightTrusterParticles.isPlaying)
        {
            rightTrusterParticles.Play();
        }
    }

    private void RotateRight()
    {
        Rotate(-rotationPower);
        if (!leftTrusterParticles.isPlaying)
        {
            leftTrusterParticles.Play();
        }
    }

    private void Rotate(float z)
    {
        // freezing physical rotation when colide
        rb.freezeRotation = true;
        transform.Rotate(0, 0, z * Time.deltaTime);
        // unfreezing rotation so the physics system can take over
        rb.freezeRotation = false;
    }
}
