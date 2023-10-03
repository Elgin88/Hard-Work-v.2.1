using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSoundWhenMinimizingWindow : MonoBehaviour
{
    private SoundController _soundController;

    private void Start()
    {
        _soundController = FindObjectOfType<SoundController>();
    }

    private void FixedUpdate()
    {

#if UNITY_EDITOR
        
#endif

#if UNITY_WEBGL

#endif

    }
}