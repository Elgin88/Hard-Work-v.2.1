using System.Collections;
using UnityEngine;

namespace HardWork
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private BlockMover _blockMover;

        private int _cost = 1;
        private Point _point;
        private bool _playerIsUnload;
        private Coroutine _timerPhysicsOff;
        private WaitForSeconds _phisicsOffTime = new WaitForSeconds(5);

        public BlockMover BlockMover => _blockMover;

        public Point Point => _point;

        public int Cost => _cost;

        public void WakeUp()
        {
            _rigidbody.WakeUp();
        }

        public void GravityOn()
        {
            _rigidbody.useGravity = true;
        }

        public void GravityOff()
        {
            _rigidbody.useGravity = false;
        }

        public void ColliderOn()
        {
            _boxCollider.enabled = true;
        }

        public void ColliderOff()
        {
            _boxCollider.enabled = false;
        }

        public void KinematicOn()
        {
            _rigidbody.isKinematic = true;
        }

        public void KinematicOff()
        {
            _rigidbody.isKinematic = false;
        }

        public void SetPosition(float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        public void SetQuaternion(Quaternion currentRotation)
        {
            transform.rotation = currentRotation;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void StartTimerPhysicsOff()
        {
            if (_timerPhysicsOff == null)
            {
                _timerPhysicsOff = StartCoroutine(TimerPhysicsOff());
            }
        }

        public void StopTimerPhysicsOff()
        {
            if (_timerPhysicsOff != null)
            {
                StopCoroutine(_timerPhysicsOff);
                _timerPhysicsOff = null;
            }
        }

        private void BlocksUnloaded(bool isUnload)
        {
            _playerIsUnload = isUnload;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerRam>(out PlayerRam playerRam))
            {
                _playerMover.SlowDown();

                _point = _inventory.TakePoint();

                if (_point != null & _inventory.IsMoveBlocksToCollector == false)
                {
                    KinematicOn();
                    ColliderOff();
                    GravityOff();

                    _point.InitBlock(this);
                    _blockMover.StartMoveToPlayer();
                }
            }
        }

        private IEnumerator TimerPhysicsOff()
        {
            yield return _phisicsOffTime;

            KinematicOn();
            GravityOff();
        }
    }
}