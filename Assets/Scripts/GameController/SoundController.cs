using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void SetMaxSoundValue()
    {
        AudioListener.volume = 1;
    }

    public void SetMinSoundValue()
    {
        AudioListener.volume = 0;
    }

    public void SetMaxSoundValueInBrauser()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        AudioListener.volume = 1;
#endif
    }

    public void SetMinSoundValueInBrauser()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        AudioListener.volume = 0;
#endif
    }
}