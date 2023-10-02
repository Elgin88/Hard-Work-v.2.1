using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private Player _player;
    private EnderLevel _enderLevel;

    private string _saveKeyPlayerMoney = "PlayerMoney";
    private string _saveKeyNextLevelName = "NextLevelName";

    public string SaveKeyPlayerMoney => _saveKeyPlayerMoney;
    public string SaveKeyNextLevelName => _saveKeyNextLevelName;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _enderLevel = FindObjectOfType<EnderLevel>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _player.Money);
        PlayerPrefs.SetString(_saveKeyNextLevelName, _enderLevel.NextSceneName);
        PlayerPrefs.Save();
    }

    public void SavePrefsInCloud()
    {

#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.YandexGames.YandexGamesSdk.IsInitialized)
        {
            Agava.YandexGames.PlayerPrefs.Save();
        }        
#endif
    }
}
