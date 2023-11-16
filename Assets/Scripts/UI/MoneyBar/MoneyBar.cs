using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private UIRequireComponents _uiRequireComponents;

    private void Start()
    {
        if (_moneyCount == null || _uiRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _uiRequireComponents.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _uiRequireComponents.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}