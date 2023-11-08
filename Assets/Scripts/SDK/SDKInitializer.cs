using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializer : MonoBehaviour
{
    private void Awake()
    {
        Agava.YandexGames.YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return Agava.YandexGames.YandexGamesSdk.Initialize(OnInitizlized);
    }

    private void OnInitizlized()
    {
        SceneManager.LoadScene(SceneNames.Level0Name);
    }
}