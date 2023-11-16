using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{
    [SerializeField] private Button _loadLevelButton;
    [SerializeField] private ChooserLevelNameForLoad _chooserLevelName;

    private void Start()
    {
        if (_loadLevelButton == null || _chooserLevelName == null)
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
        SceneManager.LoadScene(_chooserLevelName.GetLoadLevelName());
    }
}