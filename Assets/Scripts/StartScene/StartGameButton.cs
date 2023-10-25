using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;

    private Loader _loader;
    private string _level1Name = "Level1";
    private string _nameSceneForLoad;

    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _loadScene;

    private void OnEnable()
    {
        _loader = FindObjectOfType<Loader>();
        _button.onClick.AddListener(OnButtonClick);

        _nameSceneForLoad = _level1Name;
    }

    private void OnButtonClick()
    {
        _audio.Play();

        if (_loader.GetSceneNameForLoad() != "")
            _nameSceneForLoad = _loader.GetSceneNameForLoad();            

        _loadScene = StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        while (true)
        {
            yield return _delay;
            SceneManager.LoadScene(_nameSceneForLoad);
        }
    }
}
