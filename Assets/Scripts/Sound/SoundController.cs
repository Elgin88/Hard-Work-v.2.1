using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private string _nameOfMixer = "Master";
    private int _maxSoundValue = 0;
    private int _minSoundValue = -80;

    public void SetMaxSoundValue()
    {
        _mixer.SetFloat(_nameOfMixer, _maxSoundValue);
    }

    public void SetMinSoundValue()
    {
        _mixer.SetFloat(_nameOfMixer, _minSoundValue);
    }
}