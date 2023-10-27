using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnderLevel _enderLevel;
    private string _saveKeyPlayerMoney = "PlayerMoney";
    private string _saveKeyNextLevelName = "NextLevelName";

    public string SaveKeyPlayerMoney => _saveKeyPlayerMoney;
    public string SaveKeyNextLevelName => _saveKeyNextLevelName;

    public void SaveData()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _player.Money);
        PlayerPrefs.SetString(_saveKeyNextLevelName, _enderLevel.NextSceneName);
        PlayerPrefs.Save();

        SavePlayerPrefsInCloud();
    }

    public void SavePlayerPrefsInCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.YandexGames.YandexGamesSdk.IsInitialized)
            Agava.YandexGames.PlayerPrefs.Save();
#endif
    }
}