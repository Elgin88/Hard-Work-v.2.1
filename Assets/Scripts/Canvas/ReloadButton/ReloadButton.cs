using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ReloadButton : MonoBehaviour
{
    [SerializeField] private Flasher1 _flasher1;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;

    private Scene _currentScene;
    private PlayerFuelController _playerFuelController;

    private void Start()
    {
        if (_flasher1 == null|| _button == null|| _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _currentScene = SceneManager.GetActiveScene();
        _playerFuelController = _canvasUI.PlayerFuelController;

        _button.onClick.AddListener(ReloadScene);
        _playerFuelController.IsFuelChanged += FlashControler;
    }

    private void FlashControler(float currentFuel, float maxFuel)
    {
        if (currentFuel==0)
        {
            _flasher1.StartFlash();
        }
        else
        {
            _flasher1.StopFlash();
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ReloadScene);
        _playerFuelController.IsFuelChanged -= FlashControler;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_currentScene.name);
    }
}
