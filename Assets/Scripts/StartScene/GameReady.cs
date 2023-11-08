using UnityEngine;

public class GameReady : MonoBehaviour
{
    private void Start()
    {
        Agava.YandexGames.YandexGamesSdk.GameReady();
    }
}