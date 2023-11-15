using System;
using UnityEngine;

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _lineOfPoints;
    [SerializeField] private PlayerRequireComponents _playerRequreComponents;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private float _rangeBetweenBlocks;
    [SerializeField] private int _maxNumberOfLines;

    public int MaxNumberOfLines => _maxNumberOfLines;
    public Action <int, int> IsChangedMaxNumberBlocks;

    private void Start()
    {
        if (_lineOfPoints == null ||
            _playerRequreComponents == null ||
            _inventory == null ||
            _playerMoney == null ||
            _rangeBetweenBlocks == 0 ||
            _maxNumberOfLines == 0)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    public void TryCreateLine()
    {
        if (_inventory.GetCountOfLines() <  _maxNumberOfLines)
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

            IsChangedMaxNumberBlocks?.Invoke(_inventory.GetCurrentCountOfBlocks(), _inventory.GetMaxCountOfBlocks());
        }
    }
}