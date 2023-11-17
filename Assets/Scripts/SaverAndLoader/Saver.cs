using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;
    [SerializeField] private ScenesNames _sceneNames;

    private string _saveKeyPlayerMoney = "SavedPlayerMoney";
    private string _saveKeyNextLevelName = "SavedLevelName";

    public string SaveKeyPlayerMoney => _saveKeyPlayerMoney;
    public string SaveKeyNextLevelName => _saveKeyNextLevelName;

    private void Start()
    {
        if (_playerMoney == null || _chooserLevelName == null || _sceneNames == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _playerMoney.Money);
        PlayerPrefs.SetString(_saveKeyNextLevelName, _chooserLevelName.GetNextSceneName());
        PlayerPrefs.Save();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(_saveKeyPlayerMoney, _playerMoney.Money);
        PlayerPrefs.Save();
    }
}