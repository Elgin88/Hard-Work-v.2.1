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

    private PlayerSoundController _playerSoundController;
    private PlayerLoadController _playerLoadController;
    private PlayerMover _mover;
    private Inventory _inventory;
    private Unloader _unloader;
    private Vector3 _collectionPointPosition;
    private int _money;
    private Loader _loader;

    public PlayerSoundController PlayerSoundController => _playerSoundController;
    public PlayerLoadController LoadController => _playerLoadController;
    public Inventory Inventory => _inventory;
    public Unloader Unloader => _unloader;
    public Vector3 CollectionPOintPosition => _collectionPointPosition;
    public float RangeBetweenBlocks => _deltaBetweenBlocks;
    public float DeltaBetweenUnloadBlocks => _deltaTimeBetweeUnloadBlocks;
    public int Money => _money;
    public int MaxHightOfInventory => _hightOfInventory;

    public event UnityAction IsPushed;
    public event UnityAction <int> IsMoneyChanged;    

    private void Start()
    {
        _collectionPointPosition = FindObjectOfType<CollectionPoint>().transform.position;
        _playerSoundController = FindObjectOfType<PlayerSoundController>();
        _loader = FindObjectOfType<Loader>();

        _mover = GetComponent<PlayerMover>();
        _playerLoadController = GetComponent<PlayerLoadController>();
        _inventory = GetComponentInChildren<Inventory>();
        _unloader = GetComponentInChildren<Unloader>();

        if (_loader.GetPlayerMoneySaved()!=0)
        {
            SetMoney(_loader.GetPlayerMoneySaved());
        }        
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
