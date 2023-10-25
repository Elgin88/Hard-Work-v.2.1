using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debug4Level0_StatusBackground : MonoBehaviour
{
    private TMP_Text _debug;

    private void Start()
    {
        _debug = GetComponent<TMP_Text>();
    }

    private void Update()
    {

#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        _debug.text = Agava.WebUtility.WebApplication.InBackground.ToString();
#endif
    }
}
