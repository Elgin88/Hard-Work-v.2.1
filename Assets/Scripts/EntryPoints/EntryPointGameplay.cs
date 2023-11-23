using UnityEngine;

namespace HardWork
{
    public class EntryPointGameplay : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _gameController;
        [SerializeField] private GameObject _directionLight;
        [SerializeField] private GameObject _eventSystem;
        [SerializeField] private GameObject _terrain;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _garage;
        [SerializeField] private GameObject _collector;
        [SerializeField] private GameObject _ui;
        [SerializeField] private GameObject _objects;

        private void Start()
        {
            EnableCamera();
            EnableGameController();
            EnableDirectionLight();
            EnableEventSystem();
            EnableTerrain();
            EnablePlayer();
            EnableGarage();
            EnableCollector();
            EnableUI();
            EnableObjects();
        }

        private void EnableCamera()
        {
            _camera.gameObject.SetActive(true);
        }

        private void EnableGameController()
        {
            _gameController.gameObject.SetActive(true);
        }

        private void EnableDirectionLight()
        {
            _directionLight.gameObject.SetActive(true);
        }

        private void EnableEventSystem()
        {
            _eventSystem.gameObject.SetActive(true);
        }

        private void EnableTerrain()
        {
            _terrain.gameObject.SetActive(true);
        }

        private void EnablePlayer()
        {
            _player.gameObject.SetActive(true);
        }

        private void EnableGarage()
        {
            _garage.gameObject.SetActive(true);
        }

        private void EnableCollector()
        {
            _collector.gameObject.SetActive(true);
        }

        private void EnableUI()
        {
            _ui.gameObject.SetActive(true);
        }

        private void EnableObjects()
        {
            _objects.gameObject.SetActive(true);
        }
    }
}