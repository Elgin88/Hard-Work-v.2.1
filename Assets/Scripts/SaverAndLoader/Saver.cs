using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private string _nameOfSceneKey = "NameOfSceneKey";
    private string _playerMoneyKey = "PlayerMoneyKey";
    private EnderLevel _enderLevel;
    private Player _player;

    public string NameOfSceneKey => _nameOfSceneKey;
    public string PlayerMoneyKey => _playerMoneyKey;

    private void Start()
    {
        _enderLevel = FindObjectOfType<EnderLevel>();
        _player = FindObjectOfType<Player>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(_nameOfSceneKey, _enderLevel.NextSceneName);
        PlayerPrefs.SetInt(_playerMoneyKey, _player.Money);
        PlayerPrefs.Save();
    }

    public void SaveDataInCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        
#endif
    }
}