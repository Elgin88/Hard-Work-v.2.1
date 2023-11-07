using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButtonSDKController : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        StartCoroutine(CheckInitSDK());
    }

    private IEnumerator CheckInitSDK()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if UNITY_WEBGL
        while (true)
        {
            if (Agava.YandexGames.YandexGamesSdk.IsInitialized)
            {
                if (_button.interactable == false)
                    _button.interactable = true;                
            }
            else
            {
                if (_button.interactable == true)
                    _button.interactable = false;
            }

            yield return null;
        }
#endif
    }
}
