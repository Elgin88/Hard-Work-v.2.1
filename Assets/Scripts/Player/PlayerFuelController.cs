using System;
using System.Collections;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class PlayerFuelController : MonoBehaviour
    {
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _deltaFuel;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private PlayerSpeedSetter _speedSetter;
        [SerializeField] private Garage _garage;

        private Coroutine _burnFuel;
        private float _currentFuel;
        private bool _isFuelLoss;

        public Action<float, float> IsFuelChanged;

        public bool IsFuelLoss => _isFuelLoss;

        public float MaxFuel => _maxFuel;

        public float CurrentFuel => _currentFuel;

        private void Start()
        {
            _currentFuel = _maxFuel;

            StartBurnFuel();
        }

        public void TryBuyFuel()
        {
            if (_playerMoney.Money > _garage.FuelCoust)
            {
                _currentFuel = _maxFuel;
                IsFuelChanged?.Invoke(_currentFuel, _maxFuel);
                _playerMoney.RemoveMoney(_garage.FuelCoust);
            }
        }

        public void TryBuyTank(int addVolumeTank)
        {
            if (_playerMoney.Money > _garage.TankCost)
            {
                _playerMoney.RemoveMoney(_garage.TankCost);
                _maxFuel += addVolumeTank;
                IsFuelChanged?.Invoke(_currentFuel, _maxFuel);
            }
        }

        public void SetMaxFuel()
        {
            _currentFuel = _maxFuel;
        }

        private IEnumerator LessFuel()
        {
            while (true)
            {
                _currentFuel -= _speedSetter.CurrentSpeed * _deltaFuel * Time.deltaTime;

                if (_currentFuel < 0)
                {
                    _currentFuel = 0;
                }

                IsFuelChanged.Invoke(_currentFuel, _maxFuel);

                if (_currentFuel <= 0)
                {
                    _isFuelLoss = true;
                }
                else
                {
                    _isFuelLoss = false;
                }

                yield return null;
            }
        }

        private void StartBurnFuel()
        {
            if (_burnFuel == null)
            {
                _burnFuel = StartCoroutine(LessFuel());
            }
        }

        private void StopBurnFuel()
        {
            if (_burnFuel != null)
            {
                StopCoroutine(_burnFuel);
                _burnFuel = null;
            }
        }
    }
}