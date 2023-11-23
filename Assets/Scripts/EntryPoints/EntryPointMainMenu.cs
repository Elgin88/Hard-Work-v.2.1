using UnityEngine;

namespace HardWork
{
    public class EntryPointMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _gameController;
        [SerializeField] private GameObject _eventSystem;
        [SerializeField] private GameObject _canvas;

        private void Start()
        {
            EnableCamera();
            EnableGameController();
            EnableEventSystem();
            EnableCanvas();
        }

        private void EnableCamera()
        {
            _camera.gameObject.SetActive(true);
        }

        private void EnableGameController()
        {
            _gameController.gameObject.SetActive(true);
        }

        private void EnableEventSystem()
        {
            _eventSystem.gameObject.SetActive(true);
        }

        private void EnableCanvas()
        {
            _canvas.gameObject.SetActive(true);
        }
    }
}