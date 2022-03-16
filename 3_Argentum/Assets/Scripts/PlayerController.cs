using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controllSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    [SerializeField] float yPositionFactor = -2f;
    [SerializeField] float xPositionFactor = 2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controllSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controllSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * yPositionFactor;
        float pitchDueToThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToThrow;
        float yaw = transform.localPosition.x * xPositionFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
