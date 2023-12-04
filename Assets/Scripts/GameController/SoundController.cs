using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void SoundOn()
    {
        AudioListener.volume = 1;
    }

    public void SoundOff()
    {
        AudioListener.volume = 0;
    }
}