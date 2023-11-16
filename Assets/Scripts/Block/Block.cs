using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private PlayerLoadController _playerLoadController;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private BlockMover _blockMover;

    private int _cost = 1;
    private Point _point;
    private bool _playerIsUnload;
    private Coroutine _timerPhysicsOff;
    private WaitForSeconds _timerWFS = new WaitForSeconds(2);

    public BlockMover BlockMover => _blockMover;
    public Point Point => _point;
    public int Cost => _cost;

    private void Start()
    {
        if (_playerLoadController == null || _inventory == null || _rigidbody == null || _boxCollider == null || _blockMover == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

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
        transform.position = new Vector3 (x, y, z);
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
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _playerMover.SlowDown();

            if (_playerIsUnload != true & _playerLoadController.IsUnload == false)
            {
                _point = _inventory.TryTakePoint();

                if (_point != null)
                {
                    KinematicOn();
                    ColliderOff();
                    GravityOff();

                    _point.InitBlock(this);
                    _blockMover.StartMoveToPlayer();
                }
            }
        }
    }

    private IEnumerator TimerPhysicsOff()
    {
        yield return _timerWFS;

        KinematicOn();
        GravityOff();
    }
}