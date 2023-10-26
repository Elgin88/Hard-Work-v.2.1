using System.Collections;
using UnityEngine;

public class Unloader : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Player _player;

    private float _deltaBetweenUnloadBlocks;
    private Coroutine _unload;
    private WaitForSeconds _deltaBetweenUnloadBlocksWFS;

    private void Start()
    {
        _deltaBetweenUnloadBlocks = _player.DeltaBetweenUnloadBlocks;        

        _deltaBetweenUnloadBlocksWFS = new WaitForSeconds(_deltaBetweenUnloadBlocks);
    }

    private IEnumerator Unload()
    {
        while (true)
        {
            Block lastAddBlock = _inventory.TryGetLastAddBlock();

            if (lastAddBlock != null)
            {
                lastAddBlock.BlockMoverToCollector.StartMoveToCollector(_player.CollectionPoint.transform.position);
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
