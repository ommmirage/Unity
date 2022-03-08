using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
            rb.AddRelativeForce(0, thrustPower * Time.deltaTime, 0);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(rotationPower);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotate(-rotationPower);
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
