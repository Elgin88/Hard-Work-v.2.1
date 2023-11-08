using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private Saver _saver;
    [SerializeField] private Player _player;
    private string _nameLevel0 = "Level0";

    public int GetPlayerMoneyCount()
    {
        return PlayerPrefs.GetInt(_saver.SaveKeyPlayerMoney);
    }

    public string GetSceneNameForLoad()
    {
        return PlayerPrefs.GetString(_saver.SaveKeyNextLevelName);
    }
}