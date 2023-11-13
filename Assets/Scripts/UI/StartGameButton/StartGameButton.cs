using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Interstitial _interstitialController;
    [SerializeField] private Loader _loader;
    [SerializeField] private PauserGame _pauserGame;

    private string _level1Name = "Level1";
    private string _nameSceneForLoad;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _loadScene;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);

        _nameSceneForLoad = _level1Name;
    }

    private void OnButtonClick()
    {
        _audio.Play();

        if (_loader.GetSceneNameForLoad() != "")
            _nameSceneForLoad = _loader.GetSceneNameForLoad();

        _loadScene = StartCoroutine(LoadScene());

        _interstitialController.ShowInterstitial();
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
