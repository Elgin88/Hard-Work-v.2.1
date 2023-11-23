using TMPro;
using UnityEngine;

namespace HardWork
{
    public class MoneyBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyCount;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            _moneyCount.text = money.ToString();
        }
    }
}