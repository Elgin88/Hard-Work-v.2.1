using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava;

public class VideoAdController : MonoBehaviour
{
    public void ShowVideoAd()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.YandexGames.YandexGamesSdk.IsInitialized)
        {
            Agava.YandexGames.VideoAd.Show();
        }        
#endif
    }
}
