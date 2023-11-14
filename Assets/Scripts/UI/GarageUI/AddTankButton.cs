using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private UIRequireComponents _UIRequireComponents;
    [SerializeField] private AudioSource _soundOfBuy;

    private void Start()
    {
        if (_cost == null || _button == null || _soundOfBuy == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _cost.text = _UIRequireComponents.Garage.TankCost.ToString();
        _button.onClick.AddListener(OnAddTankButton);

        _UIRequireComponents.Player.IsMoneyChanged += OnPlayerMoneyChanded;

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddTankButton);
        _UIRequireComponents.Player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddTankButton()
    {
        _UIRequireComponents.PlayerUpgrader.TryBuyTank();
        _soundOfBuy.Play();
        _UIRequireComponents.GarageSoundController.StartPlaySoundFinEngine();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_UIRequireComponents.Player.Money > _UIRequireComponents.Garage.TankCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}