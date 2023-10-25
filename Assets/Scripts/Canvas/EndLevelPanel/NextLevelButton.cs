using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    private VideoAdController _videoAdController;
    private SoundController _soundController;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private EnderLevel _enderLevel;
    private Button _nextLevelButton;
    private Player _player;
    private Saver _saver;
    private string _currentLevelName;

    private Coroutine _startLoadNextLevel;

    private void OnEnable()
    {
        if (_player == null)
        {
            _enderLevel = FindObjectOfType<EnderLevel>();
            _player = FindObjectOfType<Player>();
            _saver = FindObjectOfType<Saver>();
            _videoAdController = FindObjectOfType<VideoAdController>();
            _soundController = FindObjectOfType<SoundController>();
        }

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
        _saver.SaveData();

        StartLoadNextLevel();           
    }

    private IEnumerator LoadNextLevel()
    {
        yield return _delay;

        SceneManager.LoadScene(_enderLevel.NextSceneName);

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
