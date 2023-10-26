using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AddPlaceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasSoundController _soundController;
    [SerializeField] private CanvasUI _canvasUI;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAddPlaceButtonClick);
        _canvasUI.Player.IsMoneyChanged += OnMoneyChanged;

        _cost.text = _canvasUI.Garage.PlaceCost.ToString();

        SetStatusButton();        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddPlaceButtonClick);
        _canvasUI.Player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnAddPlaceButtonClick()
    {
        _canvasUI.PlayerUpgrader.TryAddPlace();
        _soundController.PlayBuySound();

        _canvasUI.GarageSoundController.StartPlaySoundFinEngine();
    }

    private void OnMoneyChanged(int money)
    {
        SetStatusButton();
    }

    private void  SetStatusButton()
    {
        if (_canvasUI.Player.Money > _canvasUI.Garage.PlaceCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}