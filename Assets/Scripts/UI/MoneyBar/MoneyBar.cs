using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private void Start()
    {
        if (_moneyCount == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _UIRequireComponents.Player.IsMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _UIRequireComponents.Player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}