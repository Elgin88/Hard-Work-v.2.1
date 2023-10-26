using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddFuelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasSoundController _canvasSoundController;
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicatorEducation;

    private string _levelName = "Level1";

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAddFuelButtonClick);
        _canvasUI.Player.IsMoneyChanged += OnPlayerMoneyChanded;
        _cost.text = _canvasUI.Garage.FuelCoust.ToString();

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddFuelButtonClick);
        _canvasUI.Player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddFuelButtonClick()
    {
        _canvasUI.PlayerUpgrader.TryBuyFuel();
        _canvasSoundController.PlayBuySound();

        _canvasUI.GarageSoundController.PlayFuelSound();

        if (_addFuelIndicatorEducation != null)
        {
            foreach (var indicator in _addFuelIndicatorEducation)
            {
                indicator.gameObject.SetActive(false);
            }
        }

        if (_canvasUI.JoystickIndicators != null)
        {
            foreach (var indicator in _canvasUI.JoystickIndicators)
            {
                indicator.gameObject.SetActive(true);
                indicator.StartFlash();
            }
        }
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_canvasUI.Player.Money > _canvasUI.Garage.FuelCoust)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
