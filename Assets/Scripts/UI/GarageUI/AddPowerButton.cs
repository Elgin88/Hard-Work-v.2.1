using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class AddPowerButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _soundOfBuy;
        [SerializeField] private UIRequireComponents _UIRequireComponents;

        private bool _isMaxLevelEngine;

        private void Start()
        {
            if (_cost == null || _button == null ||
                _soundOfBuy == null || _UIRequireComponents == null)
            {
                Debug.Log("No serializefiel in " + gameObject.name);
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
            _UIRequireComponents.PlayerMoney.IsMoneyChanged += OnMoneyChanged;
            _UIRequireComponents.PowerController.IsEngineUpgraded += OnEngineLevelChanged;
            _cost.text = _UIRequireComponents.Garage.PowerCost.ToString();

            CheckButton();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
            _UIRequireComponents.PlayerMoney.IsMoneyChanged -= OnMoneyChanged;
            _UIRequireComponents.PowerController.IsEngineUpgraded -= OnEngineLevelChanged;
        }

        private void OnButtonClick()
        {
            _UIRequireComponents.PlayerUpgrader.TryAddPower();
            _soundOfBuy.Play();
            _UIRequireComponents.GarageSoundController.StartPlaySoundFinEngine();
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
            if (_UIRequireComponents.PlayerMoney.Money > _UIRequireComponents.Garage.PowerCost & _isMaxLevelEngine == false)
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