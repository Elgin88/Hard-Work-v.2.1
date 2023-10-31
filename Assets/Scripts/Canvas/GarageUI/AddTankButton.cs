using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private CanvasSoundController _canvasSoundController;

    private void Start()
    {
        if (_cost == null || _button == null || _canvasSoundController == null || _canvasUI == null | _canvasSoundController == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _cost.text = _canvasUI.Garage.TankCost.ToString();
        _button.onClick.AddListener(OnAddTankButton);

        _canvasUI.Player.IsMoneyChanged += OnPlayerMoneyChanded;

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddTankButton);
        _canvasUI.Player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddTankButton()
    {
        _canvasUI.PlayerUpgrader.TryBuyTank();
        _canvasSoundController.PlayBuySound();
        _canvasUI.GarageSoundController.StartPlaySoundFinEngine();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_canvasUI.Player.Money > _canvasUI.Garage.TankCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}