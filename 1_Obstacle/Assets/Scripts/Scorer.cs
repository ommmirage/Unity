using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int score = 0;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag != "Hit")
        {
            Debug.Log(other.gameObject.ToString());
            other.gameObject.tag = "Hit";
            score++;
            Debug.Log("Your score is " + score);
        }
        
    }
}
