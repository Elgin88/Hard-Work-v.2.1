using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private int _hightOfInventory;
    [SerializeField] private float _deltaTimeBetweeUnloadBlocks;
    [SerializeField] private Garage _garage;
    [SerializeField] private CollectorPoint _collectionPoint;
    [SerializeField] private PlayerSoundController _soundController;
    [SerializeField] private PlayerLoadController _loadController;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Unloader _unloader;
    [SerializeField] private CollectorPoint _collectionPoin;
    [SerializeField] private Loader _loader;

    private int _money;
    private Vector3 _collectionPointPosition;

    public PlayerSoundController SoundController => _soundController;
    public PlayerLoadController LoadController => _loadController;
    public Inventory Inventory => _inventory;
    public Unloader Unloader => _unloader;
    public Vector3 CollectionPOintPosition => _collectionPointPosition;
    public float RangeBetweenBlocks => _deltaBetweenBlocks;
    public float DeltaBetweenUnloadBlocks => _deltaTimeBetweeUnloadBlocks;
    public int Money => _money;
    public int MaxHightOfInventory => _hightOfInventory;

    public Garage Garage => _garage;
    public CollectorPoint CollectionPoint => _collectionPoint;

    public event UnityAction IsPushed;
    public event UnityAction <int> IsMoneyChanged;    

    private void Start()
    {
        if (_deltaBetweenBlocks == 0 ||
            _hightOfInventory == 0 ||
            _deltaTimeBetweeUnloadBlocks == 0 ||
            _garage == null ||
            _collectionPoint == null ||
            _soundController == null ||
            _loadController == null ||
            _mover == null ||
            _inventory == null ||
            _unloader == null ||
            _collectionPoin == null ||
            _loader == null )
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _collectionPointPosition = _collectionPoin.transform.position;

        SetMoney(_loader.GetPlayerMoneyCount());
    }

    public void SlowDown()
    {
        IsPushed.Invoke();
    }

    public Quaternion GetCurrentDirection()
    {
        return _mover.CurrentPlayerDirection;
    }

    public void AddMoney(int money)
    {
        _money += money;
        IsMoneyChanged?.Invoke(_money);
    }

    public void SetMoney(int money)
    {
        _money = money;
        IsMoneyChanged?.Invoke(_money);
    }

    public void RemoveMoney(int money)
    {
        _money -= money;
        IsMoneyChanged?.Invoke(_money);
    }
}
