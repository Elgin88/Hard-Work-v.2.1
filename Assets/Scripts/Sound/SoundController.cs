using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private PlayerSpeedSetter _playerSpeedSetter;
    private string _nameOfMixer = "Master";
    private float _maxSoundValue = -10;
    private int _minSoundValue = -80;

    private void Start()
    {
        _playerSpeedSetter = FindObjectOfType<PlayerSpeedSetter>();
    }

    public void SetMaxSoundValue()
    {
        _mixer.SetFloat(_nameOfMixer, _maxSoundValue);
    }

    public void SetMinSoundValue()
    {
        _mixer.SetFloat(_nameOfMixer, _minSoundValue);
    }
}