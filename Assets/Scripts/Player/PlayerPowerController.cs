using System;
using UnityEngine;

public class PlayerPowerController : MonoBehaviour
{
    [SerializeField] private int _maxLevelEngine;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
    [SerializeField] private Garage _garage;

    private int _engineLevel;
    private bool _isMaxLevel = false;

    public bool IsMaxLevel => _isMaxLevel;
    public Action <int, bool> IsEngineUpgrade;

    private void Start()
    {
        if (_maxLevelEngine == 0 || _playerMoney == null || _playerSpeedSetter == null || _garage == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }
    }

    public void TryAddPower(float deltaPower)
    {
        if (_playerMoney.Money > _garage.PowerCost & _engineLevel < 3)
        {
            _playerSpeedSetter.ChangeDeltaPushSpeed(deltaPower);
            _playerMoney.RemoveMoney(_garage.PowerCost);
            _engineLevel++;

            if (_engineLevel == _maxLevelEngine)
                _isMaxLevel = true;

            IsEngineUpgrade?.Invoke(_engineLevel, _isMaxLevel);
        }
    }    
}