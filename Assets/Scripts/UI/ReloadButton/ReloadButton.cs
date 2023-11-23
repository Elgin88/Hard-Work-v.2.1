using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class ReloadButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UIRequireComponents _UIRequireComponents;

        private Scene _currentScene;
        private PlayerFuelController _playerFuelController;

        private void OnEnable()
        {
            _currentScene = SceneManager.GetActiveScene();
            _playerFuelController = _UIRequireComponents.PlayerFuelController;
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