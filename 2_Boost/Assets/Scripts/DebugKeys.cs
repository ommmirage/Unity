using UnityEngine;

public class DebugKeys : Levels
{
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            Levels.collisionEnabled = !Levels.collisionEnabled;
        }
    }
}
