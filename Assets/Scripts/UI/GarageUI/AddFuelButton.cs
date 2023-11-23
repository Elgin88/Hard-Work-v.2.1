using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HardWork
{
    public class AddFuelButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;
        [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicatorEducation;

        private string _levelName = "Level1";
        private string _currentSceneName;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnAddFuelButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged += OnPlayerMoneyChanded;
            _cost.text = _requireComponentsForUI.Garage.FuelCoust.ToString();

            _currentSceneName = SceneManager.GetActiveScene().name;

            CheckStatusButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAddFuelButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged -= OnPlayerMoneyChanded;
        }

        private void OnAddFuelButtonClick()
        {
            _requireComponentsForUI.PlayerUpgrader.BuyFuel();
            _soundOfBuy.Play();

            _requireComponentsForUI.GarageSoundController.PlayFuelSound();

            if (_currentSceneName == _levelName)
            {
                foreach (var indicator in _addFuelIndicatorEducation)
                {
                    indicator.gameObject.SetActive(false);
                }
            }

            if (_requireComponentsForUI.JoystickIndicators != null)
            {
                foreach (var indicator in _requireComponentsForUI.JoystickIndicators)
                {
                    if (indicator != null)
                    {
                        if (_currentSceneName == _levelName)
                        {
                            indicator.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        private void OnPlayerMoneyChanded(int money)
        {
            CheckStatusButton();
        }

        private void CheckStatusButton()
        {
            if (_requireComponentsForUI.PlayerMoney.Money > _requireComponentsForUI.Garage.FuelCoust)
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