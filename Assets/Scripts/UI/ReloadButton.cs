using HardWork.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HardWork.UI
{
    public class ReloadButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private Scene _currentScene;

        private void OnEnable()
        {
            _currentScene = SceneManager.GetActiveScene();
            _button.onClick.AddListener(ReloadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ReloadScene);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(_currentScene.name);
        }
    }
}