using System;
using UnityEngine;

public class TurnOffSoundWhenOpenVideoAd : MonoBehaviour
{
    private SoundController _soundController;
    private Action _isOn;
    private Action _isOff;

    private void OnEnable()
    {
        _soundController = FindObjectOfType<SoundController>();

        _isOn = Agava.YandexGames.VideoAd.S_onOpenCallback;
        _isOff = Agava.YandexGames.VideoAd.S_onCloseCallback;

        _isOn += SoundOff;
        _isOff += SoundOn;
    }

    private void OnDisable()
    {
        _isOn -= SoundOff;
        _isOff -= SoundOn;
    }

    private void SoundOn()
    {
        _soundController.SetMaxSoundValue();
    }

    private void SoundOff()
    {
        _soundController.SetMinSoundValue();
    }
}