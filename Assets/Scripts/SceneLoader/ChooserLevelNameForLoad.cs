using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserLevelNameForLoad : MonoBehaviour
{
    [SerializeField] private ScenesNames _sceneNames;

    private string _currentSceneName;
    private string _nextSceneName;

    public string CurrentSceneName => _currentSceneName;
    public string NextSceneName => _nextSceneName;

    private void Start()
    {
        if (_sceneNames == null)
        {
            Debug.Log("No serializefield " + gameObject.name);
        }

        _currentSceneName = SceneManager.GetActiveScene().name;
    }

    public string GetLoadLevelName()
    {
        if (_currentSceneName == _sceneNames.LevelSDK)
        {
            _nextSceneName = _sceneNames.Level0Name;
        }
        else if (_currentSceneName == _sceneNames.Level0Name)
        {
            _nextSceneName = _sceneNames.Level1Name;
        }
        else if (_currentSceneName == _sceneNames.Level1Name)
        {
            _nextSceneName = _sceneNames.Level2Name;
        }
        else if (_currentSceneName == _sceneNames.Level2Name)
        {
            _nextSceneName = _sceneNames.Level3Name;
        }
        else if (_currentSceneName == _sceneNames.Level3Name)
        {
            _nextSceneName = _sceneNames.Level1Name;
        }

        return _nextSceneName;
    }
}