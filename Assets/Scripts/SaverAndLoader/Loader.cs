using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private Saver _saver;
    private Player _player;

    private void OnEnable()
    {
        _saver = FindObjectOfType<Saver>();
        _player = FindObjectOfType<Player>();
    }

    public int GetPlayerMoneyCount()
    {
        return PlayerPrefs.GetInt(_saver.SaveKeyPlayerMoney);
    }

    public string GetSceneNameForLoad()
    {
        return PlayerPrefs.GetString(_saver.SaveKeyNextLevelName);
    }

    public void SetPlayerMoney()
    {
        _player.SetMoney(GetPlayerMoneyCount());
    }

    public void LoadPrefsFromCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.YandexGames.YandexGamesSdk.IsInitialized)
            Agava.YandexGames.PlayerPrefs.Load();
#endif
    }
}