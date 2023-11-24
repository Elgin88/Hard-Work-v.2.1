using System;
using UnityEngine;

namespace HardWork
{
    public class PlayerMoney : MonoBehaviour
    {
        [SerializeField] private RequiredComponentsForPlayer _playerRequireComponents;

        private int _money;

        public Action <int> IsMoneyChanged;

        public int Money => _money;

        private void Start()
        {
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
}