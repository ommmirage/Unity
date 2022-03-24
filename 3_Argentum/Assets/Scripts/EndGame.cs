using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    PlayerController playerController;

    TMP_Text endText;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Invoke("endGame", 15.5f);
    }

    void endGame()
    {
        endText = GetComponent<TMP_Text>();
        endText.text = "You win!";
        playerController.TakeControl();
    }
}
