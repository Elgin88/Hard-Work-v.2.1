using System.Collections;
using HardWork.Empty;
using HardWork.GameController;
using HardWork.Player;
using UnityEngine;

namespace HardWork.Block
{
    public class BlockMover : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private CalculatorBlocks _calculatorBlocks;
        [SerializeField] private ChooserMedals _chooserMedals;
        [SerializeField] private BlockSound _blockSound;
        [SerializeField] private CollectorPoint _collectorPoint;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private BlockMain _block;

        private Coroutine _moveToPlayer;
        private Coroutine _moveToCollector;
        private Coroutine _holdOnPlayer;
        private Vector3 _startBlockPosition;
        private Vector3 _topPointToPlayer;
        private Vector3 _topPointToCollector;
        private float _flightSpeedToPlayer = 10;
        private float _flightSpeedToCollector = 10;
        private float _tossHightToPlayer = 3;
        private float _tossHeightToCollector = 1;
        private bool _isReachedTopToPlayer = false;
        private bool _isReachedTopToCollector = false;

        public void StartMoveToPlayer()
        {
            if (_moveToPlayer == null)
            {
                _moveToPlayer = StartCoroutine(MoveToPlayer());
                _playerInventory.AddBlockMovingToPlayer(_block);
            }
        }

        public void StartMoveToCollector()
        {
            if (_moveToCollector == null)
            {
                _moveToCollector = StartCoroutine(MoveToCollector());
                _playerInventory.AddBlockMovingToCollector(_block);
            }
        }

        public void StartHoldBlockOnPlayer()
        {
            _block.KinematicOn();

            if (_holdOnPlayer == null)
            {
                _holdOnPlayer = StartCoroutine(HoldOnPlayer());
            }
        }

        public void StopMoveToPlayer()
        {
            if (_moveToPlayer != null)
            {
                StopCoroutine(_moveToPlayer);
                _moveToPlayer = null;
                _playerInventory.RemoveBlockMovingToPlayer(_block);
            }
        }

        public void StopMoveToCollector()
        {
            if (_moveToCollector != null)
            {
                StopCoroutine(_moveToCollector);
                _moveToCollector = null;
                _playerInventory.RemoveBlockMovingToCollector(_block);
            }
        }

        public void StopHoldBlockOnPlayer()
        {
            if (_holdOnPlayer != null)
            {
                StopCoroutine(_holdOnPlayer);
                _holdOnPlayer = null;
            }
        }

        private IEnumerator MoveToPlayer()
        {
            _startBlockPosition = transform.position;
            _blockSound.PlaySoundFlyOnCar();

            while (true)
            {
                if (_block.Point != null)
                {
                    _topPointToPlayer = new Vector3((_block.Point.transform.position.x + _startBlockPosition.x) / 2, _block.Point.transform.position.y + _tossHightToPlayer, (_block.Point.transform.position.z + _startBlockPosition.z) / 2);
                }

                if (_isReachedTopToPlayer == false & _block.Point != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _topPointToPlayer, _flightSpeedToPlayer * Time.deltaTime);

                    if (transform.position == _topPointToPlayer)
                    {
                        _isReachedTopToPlayer = true;
                    }
                }
                else if (_isReachedTopToPlayer == true & _block.Point != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _block.Point.transform.position, _flightSpeedToPlayer * Time.deltaTime);

                    if (transform.position == _block.Point.transform.position)
                    {
                        StopMoveToPlayer();
                        StartHoldBlockOnPlayer();
                        _playerInventory.InitEventBlockIsChanged();
                    }
                }

                yield return null;
            }
        }

        private IEnumerator MoveToCollector()
        {
            StopHoldBlockOnPlayer();

            _topPointToCollector = new Vector3((transform.position.x + _collectorPoint.transform.position.x) / 2, _collectorPoint.transform.position.y + transform.position.y + _tossHeightToCollector, (transform.position.z + _collectorPoint.transform.position.z) / 2);
            _block.Point.RemoveBlock();
            _playerInventory.InitEventBlockIsChanged();
            _blockSound.PlayFlyOnCollectorSFX();

            while (true)
            {
                if (_isReachedTopToCollector == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _topPointToCollector, _flightSpeedToCollector * Time.deltaTime);

                    if (transform.position == _topPointToCollector)
                    {
                        _isReachedTopToCollector = true;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, _collectorPoint.transform.position, _flightSpeedToCollector * Time.deltaTime);
                }

                if (transform.position == _collectorPoint.transform.position)
                {
                    _playerMoney.AddMoney(_block.Cost);
                    _calculatorBlocks.CalculateUnloadBloks();
                    _chooserMedals.SetMedals();
                    _blockSound.PlayBlockPlaceInCollector();

                    StopMoveToCollector();

                    Destroy(_block.gameObject);
                }

                yield return null;
            }
        }

        private IEnumerator HoldOnPlayer()
        {
            while (true)
            {
                if (_block.Point != null)
                {
                    _block.SetPosition(_block.Point.transform.position.x, _block.Point.transform.position.y, _block.Point.transform.position.z);
                    _block.SetQuaternion(_playerMover.CurrentPlayerDirection);
                }

                yield return null;
            }
        }
    }
}