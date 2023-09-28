using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava;
using UnityEngine.Audio;

public class TurnOffSoundWhenMinimizingGame : MonoBehaviour
{
    private SoundController _soundController;

    private void Start()
    {
        _soundController = FindObjectOfType<SoundController>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.WebUtility.WebApplication.InBackground == false)
        {
            _soundController.SetMaxSoundValue();
        }
        else
        {
            _soundController.SetMinSoundValue();
        }
#endif
    }
}
