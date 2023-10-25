using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class Debug2Level0_LoadLevelStatus : MonoBehaviour
{
    private TMP_Text _debug;
    private Loader _loader;

    private void Start()
    {
        _loader = FindObjectOfType<Loader>();
        _debug = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        _debug.text = _loader.GetSceneNameForLoad() + " - LevelNameForLoad";
#endif
    }
}
