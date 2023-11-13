using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ReloadButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;

    private Scene _currentScene;
    private PlayerFuelController _playerFuelController;

    private void Start()
    {
        if (_button == null|| _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _currentScene = SceneManager.GetActiveScene();
        _playerFuelController = _canvasUI.PlayerFuelController;

        _button.onClick.AddListener(ReloadScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ReloadScene);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_currentScene.name);
    }
}
