using System;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class PlayerPowerController : MonoBehaviour
    {
        [SerializeField] private int _maxLevelEngine;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
        [SerializeField] private Garage _garage;

        private int _engineLevel;
        private bool _isMaxLevel = false;

        public Action<int, bool> IsEngineUpgraded;

        public bool IsMaxLevel => _isMaxLevel;

        public void TryAddPower(float deltaPower)
        {
            if (_playerMoney.Money > _garage.PowerCost & _engineLevel < 3)
            {
                _playerSpeedSetter.ChangeDeltaPushSpeed(deltaPower);
                _playerMoney.RemoveMoney(_garage.PowerCost);
                _engineLevel++;

                if (_engineLevel == _maxLevelEngine)
                {
                    _isMaxLevel = true;
                }

                IsEngineUpgraded?.Invoke(_engineLevel, _isMaxLevel);
            }
        }
    }
}