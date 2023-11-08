using System;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnderLevel _enderLevel;

    private string _saveKeyPlayerMoney = "PlayerMoney";
    private string _saveKeyNextLevelName = "NextLevelName";

    public string SaveKeyPlayerMoney => _saveKeyPlayerMoney;
    public string SaveKeyNextLevelName => _saveKeyNextLevelName;

    private void Start()
    {
        if (_player == null || _enderLevel == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _player.Money);
        PlayerPrefs.SetString(_saveKeyNextLevelName, _enderLevel.NextSceneName);
        PlayerPrefs.Save();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _player.Money);
        PlayerPrefs.Save();
    }
}