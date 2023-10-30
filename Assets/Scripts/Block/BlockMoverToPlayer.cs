using System.Collections;
using UnityEngine;

public class BlockMoverToPlayer : MonoBehaviour
{
    [SerializeField] private BlockFixer _blockFixer;
    [SerializeField] private Block _block;
    [SerializeField] private BlockMoverToCollector _blockMoverToCollector;
    [SerializeField] private BlockSoundController _blockSoundController;

    private float _flightSpeed = 10;
    private float _tossHeight = 3;
    private Coroutine _flightWork;
    private Vector3 _topPointPosition;
    private Vector3 _startBlockPosition;
    private bool _isReachTop;

    private void Start()
    {
        if (_blockFixer == null || _block == null || _blockMoverToCollector == null || _blockSoundController == null)

        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private IEnumerator Flight()
    {
        _isReachTop = false;
        _startBlockPosition = transform.position;

        _blockSoundController.PlayFlyOnCarSFX();

        while (true)
        {
            _block.Player.LoadController.SetUploadStatus(true);

            if (_block.Point != null)
            {
                _topPointPosition = new Vector3((_block.Point.transform.position.x + _startBlockPosition.x) / 2, _block.Point.transform.position.y + _tossHeight, (_block.Point.transform.position.z + _startBlockPosition.z) / 2);
            }

            if (_isReachTop == false & _block.Point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _topPointPosition, _flightSpeed * Time.deltaTime);

                if (transform.position == _topPointPosition)
                {
                    _isReachTop = true;                    
                }
            }
            else if(_block.Point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _block.Point.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _block.Point.transform.position)
                {
                    StopCoroutineMove();

                    _blockFixer.StartCoroutineFixBlock();                    
                    _block.Player.Inventory.InitEventBlockIsChanged();
                }                               
            }

            if (_block.Point == null)
            {
                StopCoroutineMove();
                _blockMoverToCollector.StartMoveToCollector(_block.Player.CollectionPOintPosition);
            }

            yield return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StartMove()
    {
        if (_flightWork == null)
        {
            _flightWork = StartCoroutine(Flight());
        }
    }

    public void StopCoroutineMove()
    {
        if (_flightWork != null)
        {
            StopCoroutine(_flightWork);

            _flightWork = null;
        }

        _block.Player.LoadController.SetUploadStatus(false);
    }
}