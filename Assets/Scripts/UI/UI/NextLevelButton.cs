using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HardWork
{
    public class NextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        }

        private void OnNextLevelButtonClick()
        {
            _requireComponentsForUI.Saver.SaveData();
            SceneManager.LoadScene(_requireComponentsForUI.ChooserLevelNameForLoad.GetNextSceneName());
        }
    }
}