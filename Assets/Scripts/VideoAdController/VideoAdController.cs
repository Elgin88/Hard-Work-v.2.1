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
        Debug.Log("1");
        return;
#endif

#if UNITY_WEBGL
        Debug.Log("2");
        Agava.YandexGames.VideoAd.Show(null, null, OnCloseVideoAd(), null); ;
#endif
    }

    private Action OnCloseVideoAd()
    {
        Debug.Log("3");
        _pauserController.PauseOff();

        return _onCloseVideoAdCallback;
    }
}