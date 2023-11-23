using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddFuelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _soundOfBuy;
    [SerializeField] private UIRequireComponents _UIRequireComponents;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicatorEducation;

    private string _levelName = "Level1";
    private string _currentSceneName;

    private void Start()
    {
        if (_cost == null || _button == null || _soundOfBuy == null || _UIRequireComponents == null | _addFuelIndicatorEducation == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnAddFuelButtonClick);
        _UIRequireComponents.PlayerMoney.IsMoneyChanged += OnPlayerMoneyChanded;
        _cost.text = _UIRequireComponents.Garage.FuelCoust.ToString();

        _currentSceneName = SceneManager.GetActiveScene().name;

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddFuelButtonClick);
        _UIRequireComponents.PlayerMoney.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddFuelButtonClick()
    {
        _UIRequireComponents.PlayerUpgrader.TryBuyFuel();
        _soundOfBuy.Play();

        _UIRequireComponents.GarageSoundController.PlayFuelSound();

        if (_currentSceneName == _levelName)
        {
            foreach (var indicator in _addFuelIndicatorEducation)
            {
                indicator.gameObject.SetActive(false);
            }
        }

        if (_UIRequireComponents.JoystickIndicators != null)
        {
            foreach (var indicator in _UIRequireComponents.JoystickIndicators)
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
        if (_UIRequireComponents.PlayerMoney.Money > _UIRequireComponents.Garage.FuelCoust)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}