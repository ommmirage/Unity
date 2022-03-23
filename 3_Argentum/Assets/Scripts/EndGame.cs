using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    PlayerController playerController;

    TMP_Text endText;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Invoke("endGame", 14);
    }

    void endGame()
    {
        endText = GetComponent<TMP_Text>();
        endText.text = "You win!";
        CenterPlayer();
        playerController.enabled = false;
        playerController.SetGunsActive(false);
    }

    void CenterPlayer()
    {
        playerController.transform.localPosition = new Vector3();
        playerController.transform.localRotation = new Quaternion();
    }
}
