using UnityEngine;

public class PauserGame : MonoBehaviour
{
    public void PauseOffInBrauser()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Time.timeScale = 1;
        AudioListener.pause = false;
#endif
    }

    public void PauseOnInBrauser()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Time.timeScale = 0;
        AudioListener.pause = true;
#endif
    }
}