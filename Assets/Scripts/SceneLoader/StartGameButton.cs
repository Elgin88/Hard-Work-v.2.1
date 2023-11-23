using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HardWork
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _loadLevelButton;
        [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;

        private void Start()
        {
            _loadLevelButton.onClick.AddListener(OnLoadButtonClick);
        }

        private void OnDisable()
        {
            _loadLevelButton.onClick.RemoveListener(OnLoadButtonClick);
        }

        private void OnLoadButtonClick()
        {
            SceneManager.LoadScene(_chooserLevelName.GetNextSceneName());
        }
    }
}