using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        Debug.Log(xThrow);

        float yThrow = Input.GetAxis("vertical");
        Debug.Log(yThrow);
    }
}
