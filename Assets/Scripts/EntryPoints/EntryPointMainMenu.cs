using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _gameController;
    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _canvas;

    private void Start()
    {
        if (_camera == null ||
            _gameController == null ||
            _eventSystem == null ||
            _canvas == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        InitCamera();
        InitGameController();
        InitEventSystem();
        InitCanvas();   
    }

    private void InitCamera()
    {
        _camera.gameObject.SetActive(true);
    }

    private void InitGameController()
    {
        _gameController.gameObject.SetActive(true);
    }

    private void InitEventSystem()
    {
        _eventSystem.gameObject.SetActive(true);
    }

    private void InitCanvas()
    {
        _canvas.gameObject.SetActive(true);
    }
}