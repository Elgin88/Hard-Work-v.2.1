using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{
    [SerializeField] private Button _loadLevelButton;
    [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;
    [SerializeField] private UIRequireComponents _uiRequireComponents;
    [SerializeField] private Advertising _advertising;
    [SerializeField] private ScenesNames _sceneNames;

    private void Start()
    {
        if (_loadLevelButton == null || _chooserLevelName == null || _sceneNames == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        _loadLevelButton.onClick.AddListener(OnLoadButtonClick);
    }

    private void OnDisable()
    {
        _loadLevelButton.onClick.RemoveListener(OnLoadButtonClick);
    }

    private void OnLoadButtonClick()
    {
        if (SceneManager.GetActiveScene().name == _sceneNames.Level0Name)
        {
            _advertising.ShowInterstitialAd();
        }
        else
        {
            _uiRequireComponents.Advertising.ShowInterstitialAd();
        }

        SceneManager.LoadScene(_chooserLevelName.GetLoadLevelName());
    }
}