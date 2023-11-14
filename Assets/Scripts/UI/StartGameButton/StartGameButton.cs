using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Loader _loader;
    [SerializeField] private PauserGame _pauserGame;
    [SerializeField] private Advertising _advertising;

    private string _level1Name = "Level1";
    private string _nameSceneForLoad;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _loadScene;

    private void Start()
    {
        if (_button == null || _audio == null || _loader == null || _pauserGame == null || _advertising == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        _button.onClick.AddListener(OnButtonClick);

        _nameSceneForLoad = _level1Name;
    }

    private void OnButtonClick()
    {
        _audio.Play();

        if (_loader.GetSceneNameForLoad() != "")
            _nameSceneForLoad = _loader.GetSceneNameForLoad();

        _advertising.ShowInterstitialAd();

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
