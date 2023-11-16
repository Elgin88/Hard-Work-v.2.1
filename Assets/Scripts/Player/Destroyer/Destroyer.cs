using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private PlayerInventory _inventory;

    public PlayerMoney PlayerMoney => _playerMoney;
    public PlayerInventory Inventory => _inventory;

    private void Start()
    {
        if (_playerMoney == null || _inventory == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}