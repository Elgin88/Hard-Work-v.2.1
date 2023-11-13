using System;
using UnityEngine;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private PauserGame _pauserController;

    private void Start()
    {
        if (_pauserController == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private Action _onCloseVideoAdCallback;

    public void ShowVideoAd()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.VideoAd.Show(null, null, OnCloseVideoAd, null); ;
#endif
    }

    private void OnCloseVideoAd()
    {
        _pauserController.PauseOffInBrauser();
    }
}