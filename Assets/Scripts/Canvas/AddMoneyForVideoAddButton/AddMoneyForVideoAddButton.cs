using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddMoneyForVideoAddButton : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private int _addPlayerMoney;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private float _delay;

    private WaitForSeconds _delayWFS;

    private void Start()
    {
        if (_canvasUI == null || _addPlayerMoney == 0 || _button == null || _audioSourse == null || _delay == 0)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _button.onClick.AddListener(OnButtonClick);

        _delayWFS = new WaitForSeconds(_delay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _canvasUI.Player.AddMoney(_addPlayerMoney);        
        _audioSourse.Play();

        StartCoroutine(ShowVideoAd());
    }

    public IEnumerator ShowVideoAd()
    {
        yield return _delayWFS;

        _canvasUI.VideoAddController.ShowVideoAd();
        _canvasUI.PauserGame.PauseOn();

        StopCoroutine(ShowVideoAd());
    }
}