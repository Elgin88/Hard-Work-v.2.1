using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private Button _endLevelButton;
    [SerializeField] private EndLevelPanel _endLevelPanel;

    private void Start()
    {
        if (_endLevelButton == null || _endLevelPanel == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _endLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        if (_endLevelButton != null)
        {
            _endLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        }        
    }

    private void OnNextLevelButtonClick()
    {
        _endLevelPanel.gameObject.SetActive(true);
    }
}
