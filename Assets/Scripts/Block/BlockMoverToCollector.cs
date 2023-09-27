using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockSoundController))]
[RequireComponent(typeof(Block))]
[RequireComponent(typeof(BlockFixer))]

public class BlockMoverToCollector : MonoBehaviour
{
    private float _flightSpeed = 10;
    private float _tossHight = 0.005f;
    private float _deltaPointPosition = 0.001f;
    private float _deltaHight = 0.005f;

    private BlockSoundController _soundController;
    private CalculatorBlocks _calculatorBlocks;
    private BlockFixer _blockFixer;
    private Coroutine _move;
    private Vector3 _collectionPoint;
    private Vector3 _topPoint;
    private Block _block;
    private bool _isReachedTopPoint = false;

    private ChooserMedals _chooserMedals;

    private IEnumerator MoveToCollector()
    {
        if (_blockFixer == null)
        {
            _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
            _chooserMedals = FindObjectOfType<ChooserMedals>();
            _blockFixer = GetComponent<BlockFixer>();
            _block = GetComponent<Block>();
            _soundController = GetComponent<BlockSoundController>();
        }

        _blockFixer.StopCoroutineFixBlock();

        _collectionPoint = new Vector3(_collectionPoint.x + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition), _collectionPoint.y, _collectionPoint.z + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition));

        SetTopPointPosition();

        _block.Point.RemoveBlock();
        _block.Player.Inventory.InitEventBlockIsChanged();

        _soundController.PlayFlyOnCollectorSFX();

        while (true)
        {
            _block.Player.LoadController.SetUploadStatus(true);

            if (_isReachedTopPoint == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _topPoint, _flightSpeed * Time.deltaTime);

                if (transform.position == _topPoint)
                {
                    _isReachedTopPoint = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _collectionPoint, _flightSpeed * Time.deltaTime);
            }

            if (transform.position.y - _collectionPoint.y == 0)
            {
                _block.Player.AddMoney(_block.Cost);
                _calculatorBlocks.CalculateUnloadBloks();
                _chooserMedals.ChooseMedals();
                _soundController.PlayBlockPlaceInCollector();

                StopMoveToCollector();

                _block.Destroy();
            }

            yield return null;
        }
    }

    private void SetTopPointPosition()
    {
        _topPoint = new Vector3((_block.Player.transform.position.x + _collectionPoint.x)/2 , _collectionPoint.y + transform.position.y + _tossHight + Random.Range(-1* _deltaHight, _deltaHight), (_block.Player.transform.position.z + _collectionPoint.z) / 2);
    }

    public void StartMoveToCollector(Vector3 collectionPoint)
    {
        _collectionPoint = collectionPoint;        

        if (_move == null)
        {
            _move = StartCoroutine(MoveToCollector());
        }
    }

    public void StopMoveToCollector()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
            _move = null;
        }

        _block.Player.LoadController.SetUploadStatus(false);
    }
}