using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPauseOnButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        _button.onClick.AddListener(OnPauseButtonClisk);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPauseButtonClisk);
    }

    private void OnPauseButtonClisk()
    {
        _canvasUI.PauserGame.PauseOn();
    }
}