using UnityEngine;

namespace HardWork.SDK
{
    public class GameReady : MonoBehaviour
    {
        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Agava.YandexGames.YandexGamesSdk.GameReady();
#endif
        }
    }
}