using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPlaceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _soundOfBuy;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private void Start()
    {
        if (_cost == null || _button == null || _soundOfBuy == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAddPlaceButtonClick);
        _UIRequireComponents.Player.IsMoneyChanged += OnMoneyChanged;

        _cost.text = _UIRequireComponents.Garage.PlaceCost.ToString();

        SetStatusButton();        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddPlaceButtonClick);
        _UIRequireComponents.Player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnAddPlaceButtonClick()
    {
        _UIRequireComponents.PlayerUpgrader.TryAddPlace();
        _soundOfBuy.Play();

        _UIRequireComponents.GarageSoundController.StartPlaySoundFinEngine();
    }

    private void OnMoneyChanged(int money)
    {
        SetStatusButton();
    }

    private void  SetStatusButton()
    {
        if (_UIRequireComponents.Player.Money > _UIRequireComponents.Garage.PlaceCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}