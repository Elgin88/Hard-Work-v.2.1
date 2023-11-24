using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HardWork
{
    public class AddPowerButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private bool _isMaxLevelEngine;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
            _requireComponentsForUI.PowerController.IsEngineUpgraded += OnEngineLevelChanged;
            _cost.text = _requireComponentsForUI.Garage.PowerCost.ToString();

            CheckButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
            _requireComponentsForUI.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
            _requireComponentsForUI.PowerController.IsEngineUpgraded -= OnEngineLevelChanged;
        }

        private void OnButtonClick()
        {
            _requireComponentsForUI.PlayerUpgrader.AddPower();
            _soundOfBuy.Play();
            _requireComponentsForUI.GarageSoundController.StartPlaySoundFinEngine();
        }

        private void OnMoneyChanged(int money)
        {
            CheckButton();
        }

        private void OnEngineLevelChanged(int level, bool isMaxLevel)
        {
            _isMaxLevelEngine = isMaxLevel;
            CheckButton();
        }

        private void CheckButton()
        {
            if (_requireComponentsForUI.PlayerMoney.Money > _requireComponentsForUI.Garage.PowerCost & _isMaxLevelEngine == false)
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