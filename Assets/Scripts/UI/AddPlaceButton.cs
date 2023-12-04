using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HardWork.UI
{
    public class AddPlaceButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnAddPlaceButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
            _cost.text = _requireComponentsForUI.Garage.PlaceCost.ToString();

            SetStatusButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAddPlaceButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
        }

        private void OnAddPlaceButtonClick()
        {
            _requireComponentsForUI.PlayerUpgrader.AddPlace();
            _soundOfBuy.Play();
            _requireComponentsForUI.GarageSoundController.StartPlaySoundFinEngine();
        }

        private void OnMoneyChanged(int money)
        {
            SetStatusButton();
        }

        private void SetStatusButton()
        {
            if (_requireComponentsForUI.PlayerMoney.Money > _requireComponentsForUI.Garage.PlaceCost)
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