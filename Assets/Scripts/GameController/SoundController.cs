using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        AudioListener.volume = 1;
#endif
    }

    public void SetMinSoundValueInBrauser()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        AudioListener.volume = 0;
#endif
    }
}