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
    private string _currentSceneName;

    private void Start()
    {
        if (_cost == null || _button == null || _canvasSoundController == null || _canvasUI == null | _addFuelIndicatorEducation == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAddFuelButtonClick);
        _canvasUI.Player.IsMoneyChanged += OnPlayerMoneyChanded;
        _cost.text = _canvasUI.Garage.FuelCoust.ToString();

        _currentSceneName = SceneManager.GetActiveScene().name;

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

        if (_currentSceneName == _levelName)
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
                if (indicator!=null)
                {
                    if (_currentSceneName==_levelName)
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
