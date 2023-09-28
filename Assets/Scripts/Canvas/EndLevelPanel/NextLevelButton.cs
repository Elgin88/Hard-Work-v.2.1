using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    private Button _nextLevelButton;
    private EnderLevel _enderLevel;
    private Player _player;
    private Saver _saver;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);


    private string _currentLevelName;

    private void OnEnable()
    {
        if (_player == null)
        {
            _enderLevel = FindObjectOfType<EnderLevel>();
            _player = FindObjectOfType<Player>();
            _saver = FindObjectOfType<Saver>();
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

        StartCoroutine(LoadNextLevel());
             
    }

    private IEnumerator LoadNextLevel()
    {
        yield return _delay;

        SceneManager.LoadScene(_enderLevel.NextSceneName);

        yield break;
    }

    private void ShowVideoInBrauser()
    {

    }
}
