using UnityEngine;
using HardWork;

namespace HardWork
{
    public class PauseSetter : MonoBehaviour
    {
        public void PauseOffInBrauser()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            AudioListener.pause = false;
            Time.timeScale = 1;
#endif
        }

        public void PauseOnInBrauser()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            AudioListener.pause = true;
            Time.timeScale = 0;
#endif
        }
    }
}