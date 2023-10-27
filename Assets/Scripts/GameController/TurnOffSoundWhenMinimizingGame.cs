using UnityEngine;

public class TurnOffSoundWhenMinimizingGame : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;

    private bool _isSoundOffThenMinimozing;

    private void Start()
    {
        _isSoundOffThenMinimozing = false;
    }

    private void FixedUpdate()
    {
        if (CheckInBackgrounInBrauser() == true & _isSoundOffThenMinimozing == false)
        {
            _soundController.SetMinSoundValue();
            _isSoundOffThenMinimozing = true;
        }
        else if (CheckInBackgrounInBrauser() == false & _isSoundOffThenMinimozing == true)
        {
            _soundController.SetMaxSoundValue();
            _isSoundOffThenMinimozing = false;
        }
    }

    private bool CheckInBackgrounInBrauser()
    {
#if UNITY_EDITOR
        return false;
#endif

#if UNITY_WEBGL
        return Agava.WebUtility.WebApplication.InBackground;
#endif
    }
}