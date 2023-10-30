using System.Collections;
using UnityEngine;

public class BlockFixer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Block _block;

    private Coroutine _fixBlock;

    private void Start()
    {
        if (_player==null || _block==null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private IEnumerator FixBlock()
    {
        _block.SoundController.PlayPlaceOnCarSFX();

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
    
    public void StartCoroutineFixBlock()
    {
        _block.KinematicOn();

        if (_fixBlock == null)
        {
            _fixBlock = StartCoroutine(FixBlock());
        }
    }

    public void StopCoroutineFixBlock()
    {
        if (_fixBlock != null)
        {
            StopCoroutine(_fixBlock);
            _fixBlock = null;
        }
    }
}
