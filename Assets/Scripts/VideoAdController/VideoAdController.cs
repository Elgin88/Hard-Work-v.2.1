using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SoundController))]

public class VideoAdController : MonoBehaviour
{
    [SerializeField] private PauserGame _pauserController;

    private Action _onCloseVideoAdCallback;

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