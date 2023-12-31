using System.Collections;
using HardWork.Player;
using UnityEngine;

namespace HardWork.Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;

        private Coroutine _moveWork = null;
        private float _deltaY = 10;
        private float _deltaZ = -9;
        private float _speedChangeX = 4f;
        private float _speedChangeZ = 4f;
        private float _deltaRotationX = 0.3f;
        private float _currentCameraPositionX;
        private float _currentCameraPositionY;
        private float _currentCameraPositionZ;

        private void Start()
        {
            _currentCameraPositionX = _playerMover.transform.position.x;
            _currentCameraPositionY = _playerMover.transform.position.y + _deltaY;
            _currentCameraPositionZ = _playerMover.transform.position.z + _deltaZ;

            transform.rotation = new Quaternion(_deltaRotationX, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            transform.position = new Vector3(_currentCameraPositionX, _currentCameraPositionY, _currentCameraPositionZ);

            StartCoroutineMove();
        }

        private void OnDisable()
        {
            StopCoroutineMove();
        }

        public void StartCoroutineMove()
        {
            if (_moveWork == null)
            {
                _moveWork = StartCoroutine(Move());
            }
        }

        public void StopCoroutineMove()
        {
            if (_moveWork != null)
            {
                StopCoroutine(_moveWork);
                _moveWork = null;
            }
        }

        private IEnumerator Move()
        {
            while (true)
            {
                _currentCameraPositionX = Mathf.MoveTowards(_currentCameraPositionX, _playerMover.transform.position.x, _speedChangeX * Time.deltaTime);

                _currentCameraPositionZ = Mathf.MoveTowards(_currentCameraPositionZ, _playerMover.transform.position.z + _deltaZ, _speedChangeZ * Time.deltaTime);

                transform.position = new Vector3(_currentCameraPositionX, _currentCameraPositionY, _currentCameraPositionZ);

                yield return null;
            }
        }
    }
}