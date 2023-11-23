using System.Collections;
using UnityEngine;
using HardWork;

namespace HardWork
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
                _soundController.SetMinSoundValueInBrauser();
                _isSoundOn = false;
            }
            else if (Agava.WebUtility.WebApplication.InBackground == false & _isSoundOn == false)
            {
                _soundController.SetMaxSoundValueInBrauser();
                _isSoundOn = true;
            }
#endif
        }

        private void MethodForDeleteErrorInConsol()
        {
            if (_isSoundOn)
            {
                _isSoundOn = true;
            }
        }
    }
}