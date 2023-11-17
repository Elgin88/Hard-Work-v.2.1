using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private UIRequireComponents _uiRequireComponents;

    private void Start()
    {
        if (_nextLevelButton == null || _uiRequireComponents == null)
        {
            Debug.Log("No serializefield in " + gameObject.name) ;
        }

        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        _uiRequireComponents.Saver.SaveData();
        SceneManager.LoadScene(_uiRequireComponents.ChooserLevelNameForLoad.GetNextSceneName());
    }
}