using System.Collections;
using UnityEngine;

namespace HardWork.UI
{
    public class Flasher : MonoBehaviour
    {
        private float _deltaScaleInPercentages = 30;
        private float _timeOfFlashInSeconds = 0.3f;
        private Coroutine _flash;
        private Vector3 _startScale;
        private Vector3 _currentScale;
        private Vector3 _targetScale;

        private float DeltaScale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

        private void OnEnable()
        {
            _startScale = transform.localScale;
            _currentScale = _startScale;
            _targetScale = _startScale * (100 + _deltaScaleInPercentages) / 100;

            StartFlash();
        }

        private void OnDisable()
        {
            StopFlash();
        }

        public void StartFlash()
        {
            if (_flash == null)
            {
                _flash = StartCoroutine(Flash());
            }
        }

        public void StopFlash()
        {
            if (_flash != null)
            {
                StopCoroutine(_flash);
                _flash = null;
            }
        }

        private IEnumerator Flash()
        {
            bool isForward = true;

            while (true)
            {
                if (isForward)
                {
                    _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, DeltaScale);
                    _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, DeltaScale);
                    _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, DeltaScale);

                    if (_currentScale.x >= _targetScale.x)
                    {
                        isForward = false;
                    }
                }
                else
                {
                    _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, DeltaScale);
                    _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, DeltaScale);
                    _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, DeltaScale);

                    if (_currentScale.x <= _startScale.x)
                    {
                        isForward = true;
                    }
                }

                transform.localScale = _currentScale;

                yield return null;
            }
        }
    }
}