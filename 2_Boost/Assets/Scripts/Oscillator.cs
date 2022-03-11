using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    float rand;

    void Start()
    {
        startingPos = transform.position;
        rand = Random.Range(0, 6);
    }

    void Update()
    {
        float sinWave = Mathf.Sin(Time.time + rand);

        Vector3 offset = movementVector * sinWave;
        transform.position = startingPos + offset;
    }
}
