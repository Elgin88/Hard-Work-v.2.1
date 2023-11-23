using UnityEngine;
using HardWork;

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
            InitCamera();
            InitGameController();
            InitDirectionLight();
            InitEventSystem();
            InitTerrain();
            InitPlayer();
            InitGarage();
            InitCollector();
            InitUI();
            InitObjects();
        }

        private void InitCamera()
        {
            _camera.gameObject.SetActive(true);
        }

        private void InitGameController()
        {
            _gameController.gameObject.SetActive(true);
        }

        private void InitDirectionLight()
        {
            _directionLight.gameObject.SetActive(true);
        }

        private void InitEventSystem()
        {
            _eventSystem.gameObject.SetActive(true);
        }

        private void InitTerrain()
        {
            _terrain.gameObject.SetActive(true);
        }

        private void InitPlayer()
        {
            _player.gameObject.SetActive(true);
        }

        private void InitGarage()
        {
            _garage.gameObject.SetActive(true);
        }

        private void InitCollector()
        {
            _collector.gameObject.SetActive(true);
        }

        private void InitUI()
        {
            _ui.gameObject.SetActive(true);
        }

        private void InitObjects()
        {
            _objects.gameObject.SetActive(true);
        }
    }
}