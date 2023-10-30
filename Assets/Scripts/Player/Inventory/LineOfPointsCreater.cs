using UnityEngine;
using UnityEngine.Events;

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _lineOfPoints;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Player _player;

    private float _rangeBetweenBlocks;
    private int _maxNumberOfLines;

    public int MaxNumberOfLines => _maxNumberOfLines;
    public event UnityAction <int, int> IsChangedMaxNumberBlocks;

    private void Start()
    {
        if (_lineOfPoints == null || _inventory == null || _player == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _rangeBetweenBlocks = _player.RangeBetweenBlocks;
        _maxNumberOfLines = _player.MaxHightOfInventory;
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
        if (_player.Money > _player.Garage.PlaceCost)
        {
            _maxNumberOfLines += numberLines;

            _player.RemoveMoney(_player.Garage.PlaceCost);

            IsChangedMaxNumberBlocks?.Invoke(_inventory.GetCurrentCountOfBlocks(), _inventory.GetMaxCountOfBlocks());
        }
    }
}