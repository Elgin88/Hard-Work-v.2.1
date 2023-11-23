using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class NextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private UIRequireComponents _uiRequireComponents;

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
            _uiRequireComponents.Saver.SaveData();
            SceneManager.LoadScene(_uiRequireComponents.ChooserLevelNameForLoad.GetNextSceneName());
        }
    }
}