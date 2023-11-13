using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private CalculatorBlocks _calculatorBlocks;
    [SerializeField] private ChooserMedals _chooserMedals;
    [SerializeField] private BlockSound _blockSound;
    [SerializeField] private CollectorPoint collectorPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Block _block;

    private Coroutine _moveToPlayer;
    private Coroutine _holdOnPlayer;
    private Coroutine _moveToCollector;
    private Vector3 _startBlockPosition;
    private Vector3 _topPointToPlayer;
    private Vector3 _topPointToCollector;
    private float _flightSpeedToPlayer = 10;
    private float _flightSpeedToCollector = 10;
    private float _tossHightToPlayer = 3;
    private float _tossHeightToCollector = 1;
    private bool _isReachedTopToPlayer = false;
    private bool _isReachedTopToCollector = false;

    private void Start()
    {
        if (_calculatorBlocks == null || _chooserMedals == null || _blockSound == null || 
            collectorPoint == null || _player == null || _block == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private IEnumerator MoveToPlayer()
    {
        _startBlockPosition = transform.position;
        _blockSound.PlaySoundFlyOnCar();

        while (true)
        {
            _block.Player.LoadController.SetUploadStatus(true);

            if (_block.Point != null)
            {
                _topPointToPlayer = new Vector3
                    ((_block.Point.transform.position.x + _startBlockPosition.x) / 2,
                    _block.Point.transform.position.y + _tossHightToPlayer,
                    (_block.Point.transform.position.z + _startBlockPosition.z) / 2);
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
                    _block.Player.Inventory.InitEventBlockIsChanged();
                }
            }

            if (_block.Point == null)
            {
                StopMoveToPlayer();
                StartMoveToCollector(_block.Player.CollectionPOintPosition);
            }

            yield return null;
        }
    }

    private IEnumerator HoldOnPlayer()
    {
        _block.BlockSound.PlayPlaceOnCar();

        while (true)
        {
            if (_block.Point != null)
            {
                _block.SetPosition(_block.Point.transform.position.x, _block.Point.transform.position.y, _block.Point.transform.position.z);
                _block.SetQuaternion(_player.GetCurrentDirection());
            }

            yield return null;
        }
    }

    private IEnumerator MoveToCollector()
    {
        StopFixBlock();

        _topPointToCollector = new Vector3 (
            (transform.position.x + collectorPoint.transform.position.x) / 2,
            collectorPoint.transform.position.y + transform.position.y,
            (transform.position.z + collectorPoint.transform.position.z) / 2);

        _block.Point.RemoveBlock();
        _block.Player.Inventory.InitEventBlockIsChanged();

        _blockSound.PlayFlyOnCollectorSFX();

        while (true)
        {
            _block.Player.LoadController.SetUploadStatus(true);

            if (_isReachedTopToCollector == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _topPointToCollector, _flightSpeedToCollector * Time.deltaTime);

                if (transform.position == _topPointToCollector)
                {
                    _isReachedTopToCollector = true;
                }
            }
            else if (_isReachedTopToCollector == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, collectorPoint.transform.position, _flightSpeedToCollector * Time.deltaTime);
            }

            if (transform.position.y == collectorPoint.transform.position.y)
            {
                _block.Player.AddMoney(_block.Cost);
                _calculatorBlocks.CalculateUnloadBloks();
                _chooserMedals.ChooseMedals();
                _blockSound.PlayBlockPlaceInCollector();

                StopMoveToCollector();

                _block.Destroy();
            }

            yield return null;
        }
    }

    public void StartMoveToCollector(Vector3 collectionPoint)
    {
        if (_moveToCollector == null)
        {
            _moveToCollector = StartCoroutine(MoveToCollector());
        }
    }

    public void StopMoveToCollector()
    {
        if (_moveToCollector != null)
        {
            StopCoroutine(_moveToCollector);
            _moveToCollector = null;
        }

        _block.Player.LoadController.SetUploadStatus(false);
    }


    public void StartMoveToPlayer()
    {
        if (_moveToPlayer == null)
        {
            _moveToPlayer = StartCoroutine(MoveToPlayer());
        }
    }

    public void StopMoveToPlayer()
    {
        if (_moveToPlayer != null)
        {
            StopCoroutine(_moveToPlayer);
            _moveToPlayer = null;
        }

        _block.Player.LoadController.SetUploadStatus(false);
    }


    public void StartHoldBlockOnPlayer()
    {
        _block.KinematicOn();

        if (_holdOnPlayer == null)
        {
            _holdOnPlayer = StartCoroutine(HoldOnPlayer());
        }
    }

    public void StopFixBlock()
    {
        if (_holdOnPlayer != null)
        {
            StopCoroutine(_holdOnPlayer);
            _holdOnPlayer = null;
        }
    }
}