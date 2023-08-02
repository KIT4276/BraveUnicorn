using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool _isPaused = false;
    
    public void ExitGame()
    {
         Application.Quit();
    }

    public void PauseGame()
    {
        if (!_isPaused)
        {
            Time.timeScale = 0;
            _isPaused = true;
        }

        else
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
    }
}
