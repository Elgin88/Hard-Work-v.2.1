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
        Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback, OnErrorCallbackInterstitialAd);
#endif
    }

    private void OnErrorCallbackInterstitialAd()
    {
        Debug.Log("OnErrorCallbackInterstitialAd");
    }

    private void OnCloseCallbackVideoAd()
    {
        _pauserGame.PauseOffInBrauser();
    }

    private void OnCloseCallback(bool close)
    {
        _pauserGame.PauseOffInBrauser();
    }

    private void OnOpenCallback()
    {
        _pauserGame.PauseOnInBrauser();
    }

    private void OnErrorCallback(string error)
    {
        Debug.Log("OnErrorCallback");
    }

    private void OnOfflineCallback()
    {
        Debug.Log("OnOfflineCallback");
    }

    private void OnRewardedCallback()
    {
        Debug.Log("OnRewardedCallback");
    }
}