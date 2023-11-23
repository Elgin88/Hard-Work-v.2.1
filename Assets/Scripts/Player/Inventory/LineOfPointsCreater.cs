using System;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class LineOfPointsCreater : MonoBehaviour
    {
        [SerializeField] private LineOfPoints _lineOfPoints;
        [SerializeField] private RequiredComponentsForPlayer _playerRequreComponents;
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private float _rangeBetweenBlocks;
        [SerializeField] private int _maxNumberOfLines;

        public Action<int, int> MaxNumberBlocksIsChanged;

        public int MaxNumberOfLines => _maxNumberOfLines;

        public void TryCreateLine()
        {
            if (_inventory.GetCountOfLines() < _maxNumberOfLines)
            {
                LineOfPoints line = Instantiate(_lineOfPoints, _inventory.transform);
                line.MoveUp(_rangeBetweenBlocks * _inventory.GetCountOfLines());

                _inventory.AddLine(line);
            }
        }

        public void TryAddPlace(int numberLines)
        {
            if (_playerMoney.Money > _playerRequreComponents.Garage.PlaceCost)
            {
                _maxNumberOfLines += numberLines;

                _playerMoney.RemoveMoney(_playerRequreComponents.Garage.PlaceCost);

                MaxNumberBlocksIsChanged?.Invoke(_inventory.GetCurrentCountOfBlocks(), _inventory.GetMaxCountOfBlocks());
            }
        }
    }
}