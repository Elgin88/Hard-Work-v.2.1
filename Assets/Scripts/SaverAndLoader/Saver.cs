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

    private void Start()
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
}
