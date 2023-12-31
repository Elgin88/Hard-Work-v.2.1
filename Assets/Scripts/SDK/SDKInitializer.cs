using System.Collections;
using HardWork.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HardWork.SDK
{
    public class SDKInitializer : MonoBehaviour
    {
        [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Agava.YandexGames.YandexGamesSdk.CallbackLogging = true;
#endif
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        private IEnumerator Start()
        {
            yield return Agava.YandexGames.YandexGamesSdk.Initialize(OnInitizlized);
        }
#endif

        private void OnInitizlized()
        {
            SceneManager.LoadScene(_chooserLevelName.GetNextSceneName());
        }
    }
}