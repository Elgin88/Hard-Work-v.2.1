using UnityEngine;
using UnityEngine.UI;

public class TempPauseOnButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        if (_button == null || _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _button.onClick.AddListener(OnPauseButtonClisk);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPauseButtonClisk);
    }

    private void OnPauseButtonClisk()
    {
        _canvasUI.PauserGame.PauseOnInBrauser();
    }
}