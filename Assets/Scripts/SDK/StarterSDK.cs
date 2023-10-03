using System.Collections;
using TMPro;
using UnityEngine;

public class StarterSDK : MonoBehaviour
{
    [SerializeField] private TMP_Text _debug1;

//    private IEnumerator Start()
//    {
//#if UNITY_EDITOR
//        yield break;
//#endif

//#if UNITY_WEBGL
        
//#endif
//    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return ;
#endif

#if UNITY_WEBGL
        
#endif
    }
}