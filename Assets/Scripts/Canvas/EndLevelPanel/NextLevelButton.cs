using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;
    [SerializeField] private Button _nextLevelButton;

    private WaitForSeconds _delay = new WaitForSeconds(0.5f);    
    private string _currentLevelName;
    private Coroutine _startLoadNextLevel;

    private void OnEnable()
    {
        _currentLevelName = SceneManager.GetActiveScene().name;

        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        _canvasUI.Saver.SaveData();

        StartLoadNextLevel();           
    }

    private IEnumerator LoadNextLevel()
    {
        yield return _delay;

        SceneManager.LoadScene(_canvasUI.EndelLevel.NextSceneName);

        StopLoadNextLevel();
    }

    private void StartLoadNextLevel()
    {
        if (_startLoadNextLevel==null)
        {
            _startLoadNextLevel = StartCoroutine(LoadNextLevel());
        }
    }

    private void StopLoadNextLevel()
    {
        StopCoroutine(_startLoadNextLevel);
        _startLoadNextLevel = null;
    }
}