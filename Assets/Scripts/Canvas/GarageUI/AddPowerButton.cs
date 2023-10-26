using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPowerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private EngineBarIconFlash _flash;
    [SerializeField] private CanvasSoundController _soundController;
    [SerializeField] private CanvasUI _canvasUI;

    private bool _isMaxLevelEngine;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        _canvasUI.Player.IsMoneyChanged += OnMoneyChanged;
        _canvasUI.PowerController.IsEngineUpgrade += OnEngineLevelChanged;

        _cost.text = _canvasUI.Garage.PowerCost.ToString();

        CheckButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _canvasUI.Player.IsMoneyChanged -= OnMoneyChanged;
        _canvasUI.PowerController.IsEngineUpgrade -= OnEngineLevelChanged;
    }

    private void OnButtonClick()
    {
        _canvasUI.PlayerUpgrader.TryAddPower();
        _soundController.PlayBuySound();
        _canvasUI.GarageSoundController.StartPlaySoundFinEngine();
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
        if (_canvasUI.Player.Money > _canvasUI.Garage.PowerCost & _isMaxLevelEngine == false)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}