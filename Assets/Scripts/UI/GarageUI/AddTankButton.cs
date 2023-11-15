using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _soundOfBuy;
    [SerializeField] private UIRequireComponents _uiRequireComponents;

    private void Start()
    {
        if (_cost == null || _button == null || _soundOfBuy == null || _uiRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _cost.text = _uiRequireComponents.Garage.TankCost.ToString();
        _button.onClick.AddListener(OnAddTankButton);
        _uiRequireComponents.PlayerMoney.IsMoneyChanged += OnPlayerMoneyChanded;
        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddTankButton);
        _uiRequireComponents.PlayerMoney.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddTankButton()
    {
        _uiRequireComponents.PlayerUpgrader.TryBuyTank();
        _soundOfBuy.Play();
        _uiRequireComponents.GarageSoundController.StartPlaySoundFinEngine();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_uiRequireComponents.PlayerMoney.Money > _uiRequireComponents.Garage.TankCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}