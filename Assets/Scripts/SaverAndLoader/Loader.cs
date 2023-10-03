using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private Saver _saver;

    private void OnEnable()
    {
        _saver = FindObjectOfType<Saver>();
    }

    public void GetDataFromCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        
#endif
    }

    public string GetNextLevelNameSaved()
    {
        GetDataFromCloud();

        return PlayerPrefs.GetString(_saver.NameOfSceneKey);
    }

    public int GetPlayerMoneySaved()
    {
        GetDataFromCloud();

        return PlayerPrefs.GetInt(_saver.PlayerMoneyKey);
    }
}
