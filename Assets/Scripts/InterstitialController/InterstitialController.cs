using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstitialController : MonoBehaviour
{
    public void ShowInterstitial()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.InterstitialAd.Show();
#endif
    }
}