using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class AddPlaceButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private UIRequireComponents _uiRequireComponents;

        private void Start()
        {
            if (_cost == null || _button == null ||
                _soundOfBuy == null || _uiRequireComponents == null)
            {
                Debug.Log("No serializefiel in " + gameObject.name);
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnAddPlaceButtonClick);
            _uiRequireComponents.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
            _cost.text = _uiRequireComponents.Garage.PlaceCost.ToString();

            SetStatusButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAddPlaceButtonClick);
            _uiRequireComponents.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
        }

        private void OnAddPlaceButtonClick()
        {
            _uiRequireComponents.PlayerUpgrader.TryAddPlace();
            _soundOfBuy.Play();
            _uiRequireComponents.GarageSoundController.StartPlaySoundFinEngine();
        }

        private void OnMoneyChanged(int money)
        {
            SetStatusButton();
        }

        private void SetStatusButton()
        {
            if (_uiRequireComponents.PlayerMoney.Money > _uiRequireComponents.Garage.PlaceCost)
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