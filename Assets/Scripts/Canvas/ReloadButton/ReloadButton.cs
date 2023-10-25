using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ReloadButton : MonoBehaviour
{
    [SerializeField] private Flasher1 _flasher1;

    private Button _button;
    private Scene _currentScene;
    private PlayerFuelController _playerFuelController;

    private void OnEnable()
    {
        _currentScene = SceneManager.GetActiveScene();
        _playerFuelController = FindObjectOfType<PlayerFuelController>();
        _button = GetComponent<Button>();

        
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
