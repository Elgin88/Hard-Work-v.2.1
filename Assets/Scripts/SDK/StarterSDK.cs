using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Agava.YandexGames;

public class StarterSDK : MonoBehaviour
{
    private IEnumerator Start()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
        
#endif
    }
}