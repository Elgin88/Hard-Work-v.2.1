using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private Saver _saver;
    private Player _player;
    private string _nameLevel0 = "Level0";

    private void OnEnable()
    {
        _saver = FindObjectOfType<Saver>();
        _player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == _nameLevel0)
            LoadPlayerPrefsFromCloud();         
    }

    public int GetPlayerMoneyCount()
    {
        return PlayerPrefs.GetInt(_saver.SaveKeyPlayerMoney);
    }

    public string GetSceneNameForLoad()
    {
        return PlayerPrefs.GetString(_saver.SaveKeyNextLevelName);
    }

    public void LoadPlayerPrefsFromCloud()
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