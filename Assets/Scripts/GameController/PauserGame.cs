using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauserGame : MonoBehaviour
{
    public void PauseOff()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void PauseOn()
    {
        Time.timeScale = 0.000000000000001f;
        AudioListener.pause = true;
    }
}
