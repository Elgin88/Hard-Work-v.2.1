using UnityEngine;

public class GameReady : MonoBehaviour
{
    private void Start()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.YandexGamesSdk.GameReady();
#endif
    }
}