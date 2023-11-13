using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    public void ShowVideoAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.VideoAd.Show();
#endif
    }
}
