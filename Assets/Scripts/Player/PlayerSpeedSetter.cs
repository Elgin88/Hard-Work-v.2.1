using System.Collections;
using UnityEngine;

namespace HardWork.Player
{
    public class PlayerSpeedSetter : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _deltaUpSpeed;
        [SerializeField] private float _deltaDownSpeed;
        [SerializeField] private float _pushChangeSpeed;
        [SerializeField] private float _delayPush;
        [SerializeField] private PlayerSoundController _soundController;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerFuelController _playerFuelController;

        private Coroutine _changeSpeedWork;
        private float _timeAftetLastPush;
        private float _currentSpeed;

        public float DeltaDownSpeed => _deltaDownSpeed;

        public float CurrentSpeed => _currentSpeed;

        public float DeltaUpSpeed => _deltaUpSpeed;

        public float MaxSpeed => _maxSpeed;

        public float MinSpeed => _minSpeed;

        private void Start()
        {
            _playerMover.IsPushed += IsPushedPlayer;

            StartCoroutineChangeSpeed();
        }

        public void ChangeDeltaPushSpeed(float deltaPush)
        {
            _pushChangeSpeed -= deltaPush;

            if (_pushChangeSpeed <= 0)
            {
                _pushChangeSpeed = 0;
            }
        }

        private void Update()
        {
            _timeAftetLastPush += Time.deltaTime;
        }

        private void OnDisable()
        {
            _playerMover.IsPushed -= IsPushedPlayer;
        }

        private IEnumerator ChangeSpeed()
        {
            while (true)
            {
                if (_playerMover.IsJoystickTurn == true & _playerFuelController.IsFuelLoss == false)
                {
                    _currentSpeed = Mathf.MoveTowards(_currentSpeed, _maxSpeed, _deltaUpSpeed * Time.deltaTime);
                }
                else
                {
                    _currentSpeed = Mathf.MoveTowards(_currentSpeed, _minSpeed, _deltaDownSpeed * Time.deltaTime);
                }

                if (_playerFuelController.IsFuelLoss == true)
                {
                    _playerMover.StopCoroutineMove();
                    _soundController.StopMinEngineSound();
                    _soundController.StopMaxEngineSound();
                }
                else
                {
                    _playerMover.StartCoroutineMove();
                }

                yield return null;
            }
        }

        private void IsPushedPlayer()
        {
            if (_delayPush < _timeAftetLastPush)
            {
                _currentSpeed -= _pushChangeSpeed;

                if (_currentSpeed < 0)
                {
                    _currentSpeed = 0;
                }

                _timeAftetLastPush = 0;
            }
        }

        private void StartCoroutineChangeSpeed()
        {
            if (_changeSpeedWork == null)
            {
                _changeSpeedWork = StartCoroutine(ChangeSpeed());
            }
        }
    }
}