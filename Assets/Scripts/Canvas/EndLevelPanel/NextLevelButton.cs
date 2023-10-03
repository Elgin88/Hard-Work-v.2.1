using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    private Saver _saver;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private SoundController _soundController;
    private EnderLevel _enderLevel;
    private Button _nextLevelButton;
    private Player _player;
    private string _currentLevelName;

    private void OnEnable()
    {
        _enderLevel = FindObjectOfType<EnderLevel>();
        _player = FindObjectOfType<Player>();
        _soundController = FindObjectOfType<SoundController>();
        _saver = FindObjectOfType<Saver>();

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
        _saver.SaveDataInCloud();

        StartCoroutine(LoadNextLevel());             
    }

    private IEnumerator LoadNextLevel()
    {
        yield return _delay;

        SceneManager.LoadScene(_enderLevel.NextSceneName);

        yield break;
    }
}
