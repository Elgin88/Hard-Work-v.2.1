using System.Collections;
using HardWork.Block;
using UnityEngine;

namespace HardWork.Player
{
    public class Unloader : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private RequiredComponentsForPlayer _playerRequreComponents;
        [SerializeField] private float _deltaBetweenUnloadBlocks;

        private Coroutine _unload;
        private WaitForSeconds _deltaBetweenUnloadBlocksWFS;

        private void Start()
        {
            _deltaBetweenUnloadBlocksWFS = new WaitForSeconds(_deltaBetweenUnloadBlocks);
        }

        public void StartUnload()
        {
            if (_unload == null)
            {
                _unload = StartCoroutine(BlockMoveToCollector());
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

        private IEnumerator BlockMoveToCollector()
        {
            while (true)
            {
                BlockMain lastAddBlock = _inventory.GetLastAddBlock();

                if (lastAddBlock != null & _inventory.CountOfBlocksMovingToPlayer == 0)
                {
                    lastAddBlock.BlockMover.StartMoveToCollector();
                    lastAddBlock.Point.RemoveBlock();

                    if (_inventory.GetNumberBloksInTopLine() == 0 & _inventory.GetCountOfLines() > 1)
                    {
                        _inventory.RemoveTopLine();
                    }

                    if (_inventory.GetCurrentCountOfBlocks() == 0)
                    {
                        StopUnload();
                    }
                }

                yield return _deltaBetweenUnloadBlocksWFS;
            }
        }
    }
}