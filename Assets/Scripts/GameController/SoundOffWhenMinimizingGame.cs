using UnityEngine;

namespace HardWork.GameController
{
    public class SoundOffWhenMinimizingGame : MonoBehaviour
    {
        [SerializeField] private PauseSetter _pauserGame;
        [SerializeField] private SoundController _soundController;

        private bool _isSoundOn = true;

        private void Update()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (Agava.WebUtility.WebApplication.InBackground == true & _isSoundOn == true)
            {
                _soundController.SoundOff();
                _isSoundOn = false;
            }
            else if (Agava.WebUtility.WebApplication.InBackground == false & _isSoundOn == false)
            {
                _soundController.SoundOn();
                _isSoundOn = true;
            }
#endif
        }
    }
}