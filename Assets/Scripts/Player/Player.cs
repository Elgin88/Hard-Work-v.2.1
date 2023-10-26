using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerLoadController))]
[RequireComponent(typeof(PlayerSoundController))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private int _hightOfInventory;
    [SerializeField] private float _deltaTimeBetweeUnloadBlocks;
    [SerializeField] private Garage _garage;
    [SerializeField] private CollectionPoint _collectionPoint;

    private PlayerSoundController _soundController;
    private PlayerLoadController _loadController;
    private PlayerMover _mover;
    private Inventory _inventory;
    private Unloader _unloader;
    private Vector3 _collectionPointPosition;
    private Loader _loader;
    private int _money;

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
    public CollectionPoint CollectionPoint => _collectionPoint;

    public event UnityAction IsPushed;
    public event UnityAction <int> IsMoneyChanged;    

    private void Start()
    {
        _collectionPointPosition = FindObjectOfType<CollectionPoint>().transform.position;
        _loader = FindObjectOfType<Loader>();

        _soundController = GetComponent<PlayerSoundController>();
        _loadController = GetComponent<PlayerLoadController>();
        _inventory = GetComponentInChildren<Inventory>();
        _unloader = GetComponentInChildren<Unloader>();
        _mover = GetComponent<PlayerMover>();

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
