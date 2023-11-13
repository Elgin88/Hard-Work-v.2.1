using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(BlockSound))]

public class Block : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private BlockSound _blockSound;
    [SerializeField] private BlockMover _blockMover;

    private int _cost = 1;
    private Point _point;
    private bool _playerIsUnload;
    private Coroutine _timerPhysicsOff;
    private WaitForSeconds _timerWFS = new WaitForSeconds(2);

    public BlockMover BlockMover => _blockMover;
    public BlockSound BlockSound => _blockSound;
    public Player Player => _player;
    public Point Point => _point;
    public int Cost => _cost;

    private void Start()
    {
        if (_player == null || _rigidbody == null || _boxCollider == null || _blockSound == null || _blockMover == null)

        {
            Debug.Log("No serializefiel in " + gameObject.name);
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
            _player.SlowDown();

            if (_playerIsUnload != true & _player.LoadController.IsUnload == false)
            {
                _point = _player.Inventory.TryTakePoint();

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

    internal void Init(Player player)
    {
        _player = player;
    }

    private IEnumerator TimerPhysicsOff()
    {
        yield return _timerWFS;

        KinematicOn();
        GravityOff();
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
}