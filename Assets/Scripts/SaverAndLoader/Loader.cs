using UnityEngine;

namespace HardWork
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private Saver _saver;

        public int GetPlayerMoneyCount()
        {
            return PlayerPrefs.GetInt(_saver.SaveKeyPlayerMoney);
        }

        public string GetSceneNameForLoad()
        {
            return PlayerPrefs.GetString(_saver.SaveKeyNextLevelName);
        }
    }
}