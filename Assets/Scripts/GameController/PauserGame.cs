using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauserGame : MonoBehaviour
{
    public void PauseOffInBrauser()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Time.timeScale = 1;
        AudioListener.pause = false;
#endif
    }

    public void PauseOnInBrauser()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Time.timeScale = 0.000000000000001f;
        AudioListener.pause = true;
#endif
    }
}
