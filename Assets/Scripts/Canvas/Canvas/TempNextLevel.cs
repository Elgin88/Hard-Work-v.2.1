using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TempNextLevel : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_canvasUI.EnderLevel.NextSceneName);
    }
}
