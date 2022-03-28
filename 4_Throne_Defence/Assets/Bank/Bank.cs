using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 100;

    [SerializeField] int balance;
    public int Balance { get { return balance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake() 
    {
        balance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        balance += amount;
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        balance -= amount;

        if (balance < 0)
        {
            GameOver();
        }

        UpdateDisplay();
    }

    void GameOver()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + balance;
    }
}
