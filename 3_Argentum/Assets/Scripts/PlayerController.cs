using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("Max x axis deviation")]
    [SerializeField] float xRange = 10f;
    [Tooltip("Max y axis deviation")]
    [SerializeField] float yRange = 10f;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2.3f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Gun array")]
    [Tooltip("Add all player guns here")]
    [SerializeField] GameObject[] guns;

    float xThrow;
    float yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetGunsActive(true);
        }
        else 
        {
            SetGunsActive(false);
        }
    }

    public void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
            {
                var emissionModule = gun.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isActive;
            }
    }
    
}
