using System;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    [SerializeField] private PauserGame _pauserGame;

    private void Start()
    {
        if (_pauserGame == null)
        {
            Debug.Log("No serializefield + " + gameObject.name);
        }
    }

    public void ShowVideoAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallbackVideoAd, OnErrorCallback);
#endif
    }

    public void ShowInterstitialAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallbackInterstitialAd, OnErrorCallback, OnErrorCallbackInterstitialAd);
#endif
    }

    private void OnErrorCallbackInterstitialAd()
    {
        
    }

    private void OnCloseCallbackVideoAd()
    {
        _pauserGame.PauseOffInBrauser();
    }

    private void OnCloseCallbackInterstitialAd(bool close)
    {
        _pauserGame.PauseOffInBrauser();
    }

    private void OnOpenCallback()
    {
        _pauserGame.PauseOnInBrauser();
    }

    private void OnErrorCallback(string error)
    {
        
    }

    private void OnOfflineCallback()
    {
        
    }

    private void OnRewardedCallback()
    {
        
    }
}