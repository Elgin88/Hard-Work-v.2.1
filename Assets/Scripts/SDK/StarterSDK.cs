using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Agava.YandexGames;

public class StarterSDK : MonoBehaviour
{
    [SerializeField] private TMP_Text _statusSDK;

    private IEnumerator Start()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
        
#endif
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        _statusSDK.text = YandexGamesSdk.IsInitialized.ToString() + " - status SDK";
#endif

    }
}