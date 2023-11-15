using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private PlayerRequireComponents _playerRequireComponents;

    private int _money;
    public int Money => _money;
    public Action <int> IsMoneyChanged;

    private void Start()
    {
        if (_playerRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        SetMoney(_playerRequireComponents.Loader.GetPlayerMoneyCount());
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