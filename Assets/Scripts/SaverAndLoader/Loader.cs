using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private Saver _saver;
    [SerializeField] private Player _player;
    private string _nameLevel0 = "Level0";

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