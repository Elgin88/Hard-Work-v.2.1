using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debug1Level0_SDKStatus : MonoBehaviour
{
    private TMP_Text _debug;

    private void Start()
    {
        _debug = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return;
#endif

        _debug.text = Agava.YandexGames.YandexGamesSdk.IsInitialized.ToString() + " - SDKStatus";
    }
}
