using UnityEngine;
using UnityEngine.UI;

public class TempPauseOffButton : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private Button _button;

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
        _canvasUI.PauserGame.PauseOff();
    }
}