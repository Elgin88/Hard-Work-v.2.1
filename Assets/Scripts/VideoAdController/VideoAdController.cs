using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SoundController))]

public class VideoAdController : MonoBehaviour
{
    private PauserGame _pauserController;
    private Action _onCloseVideoAdCallback;

    private void Start()
    {
        _pauserController = FindObjectOfType<PauserGame>();
    }

    public void ShowVideoAd()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.VideoAd.Show(null, null, OnCloseVideoAd(), null); ;
#endif
    }

    private Action OnCloseVideoAd()
    {
        _pauserController.PauseOff();

        return _onCloseVideoAdCallback;
    }
}