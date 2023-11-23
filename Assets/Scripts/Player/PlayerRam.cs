using UnityEngine;

namespace HardWork
{
    public class PlayerRam : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private PlayerInventory _inventory;

        public PlayerMoney PlayerMoney => _playerMoney;

        public PlayerInventory Inventory => _inventory;
    }
}