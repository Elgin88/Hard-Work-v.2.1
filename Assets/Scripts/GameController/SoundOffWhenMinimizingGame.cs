using System.Collections;
using UnityEngine;

public class SoundOffWhenMinimizingGame : MonoBehaviour
{
    [SerializeField] private PauserGame _pauserGame;
    [SerializeField] private SoundController _soundController;

    private bool _isSoundOn = true;

    private void Start()
    {
        if (_pauserGame == null || _soundController == null)
        {
            Debug.Log("No serializeField in " + gameObject.name);
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.WebUtility.WebApplication.InBackground==true & _isSoundOn == true)
        {
            _soundController.SetMinSoundValueInBrauser();
            _isSoundOn = false;
        }
        else if(Agava.WebUtility.WebApplication.InBackground == false & _isSoundOn == false)
        {
            _soundController.SetMaxSoundValueInBrauser();
            _isSoundOn = true;
        }
#endif
    }
}