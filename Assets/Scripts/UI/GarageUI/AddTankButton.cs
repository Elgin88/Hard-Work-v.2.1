using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HardWork
{
    public class AddTankButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            _cost.text = _requireComponentsForUI.Garage.TankCost.ToString();
            _button.onClick.AddListener(OnAddTankButton);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged += OnPlayerMoneyChanded;
            CheckStatusButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAddTankButton);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged -= OnPlayerMoneyChanded;
        }

        private void OnAddTankButton()
        {
            _requireComponentsForUI.PlayerUpgrader.BuyTank();
            _soundOfBuy.Play();
            _requireComponentsForUI.GarageSoundController.StartPlaySoundFinEngine();
        }

        private void OnPlayerMoneyChanded(int money)
        {
            CheckStatusButton();
        }

        private void CheckStatusButton()
        {
            if (_requireComponentsForUI.PlayerMoney.Money > _requireComponentsForUI.Garage.TankCost)
            {
                _button.interactable = true;
            }
            else
            {
                _button.interactable = false;
            }
        }
    }
}