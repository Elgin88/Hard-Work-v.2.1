using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HardWork.Garage
{
    public class EngineBarIconColorSetter : MonoBehaviour
    {
        [SerializeField] private Color _targetColor;
        [SerializeField] private float _duration;
        [SerializeField] private Image _image;

        private Coroutine _changeColor;

        public void StartChangeColor()
        {
            if (_changeColor == null)
            {
                _changeColor = StartCoroutine(ChangeColor());
            }
        }

        public void StopChangeColor()
        {
            if (_changeColor != null)
            {
                _changeColor = StartCoroutine(ChangeColor());
                _changeColor = null;
            }
        }

        private IEnumerator ChangeColor()
        {
            while (true)
            {
                _image.CrossFadeColor(_targetColor, _duration, false, false);

                if (_image.color == _targetColor)
                {
                    StopChangeColor();
                }

                yield return null;
            }
        }
    }
}