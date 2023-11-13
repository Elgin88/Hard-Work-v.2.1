using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddMoneyForVideoAddButton : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private int _addPlayerMoney;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _moneySound;

    private WaitForSeconds _delayPressButton = new WaitForSeconds(2);

    private void Start()
    {
        if (_canvasUI == null || _addPlayerMoney == 0 || _button == null || _moneySound == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _canvasUI.Player.AddMoney(_addPlayerMoney);
        _canvasUI.Saver.SaveMoney();
        _moneySound.Play();

        _button.interactable = false;

        StartCoroutine(DelayForDoubleClick());
        ShowVideoAd();
    }

    private IEnumerator DelayForDoubleClick()
    {
        yield return _delayPressButton;

        _button.interactable = true ;
    }

    public void ShowVideoAd()
    {
        _canvasUI.Advertising.ShowVideoAd();
        _canvasUI.PauserGame.PauseOnInBrauser();
    }
}