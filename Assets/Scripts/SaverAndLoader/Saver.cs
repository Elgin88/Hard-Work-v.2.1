using UnityEngine;

namespace HardWork
{
    public class Saver : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;

        private string _saveKeyPlayerMoney = "SavedPlayerMoney";
        private string _saveKeyNextLevelName = "SavedLevelName";

        public string SaveKeyPlayerMoney => _saveKeyPlayerMoney;

        public string SaveKeyNextLevelName => _saveKeyNextLevelName;

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
}