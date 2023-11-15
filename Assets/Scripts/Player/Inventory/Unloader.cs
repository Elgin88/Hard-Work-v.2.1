using System.Collections;
using UnityEngine;

public class Unloader : MonoBehaviour
{
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private PlayerRequireComponents _playerRequreComponents;
    [SerializeField] private float _deltaBetweenUnloadBlocks;

    private Coroutine _unload;
    private WaitForSeconds _deltaBetweenUnloadBlocksWFS;

    private void Start()
    {
        if (_inventory == null || _playerRequreComponents == null || _deltaBetweenUnloadBlocks == 0)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _deltaBetweenUnloadBlocksWFS = new WaitForSeconds(_deltaBetweenUnloadBlocks);
    }

    private IEnumerator Unload()
    {
        while (true)
        {
            Block lastAddBlock = _inventory.TryGetLastAddBlock();

            if (lastAddBlock != null)
            {
                lastAddBlock.BlockMover.StartMoveToCollector(_playerRequreComponents.CollectorPoint.transform.position);
                lastAddBlock.Point.RemoveBlock();

                if (_inventory.GetNumberBloksInTopLine() == 0 & _inventory.GetCountOfLines() > 1)
                {
                    _inventory.RemoveTopLine();
                }

                if (_inventory.GetCurrentCountOfBlocks () == 0)
                {
                    StopUnload();
                }
            }

            yield return _deltaBetweenUnloadBlocksWFS;

        }
    }

    public void StartUnload()
    {
        if (_unload == null)
        {
            _unload = StartCoroutine(Unload());
        }
    }

    public void StopUnload()
    {
        if (_unload != null)
        {
            StopCoroutine(_unload);
            _unload = null;
        }
    }
}