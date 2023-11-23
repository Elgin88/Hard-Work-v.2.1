using TMPro;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class MoneyBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyCount;
        [SerializeField] private UIRequireComponents _uiRequireComponents;

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
}