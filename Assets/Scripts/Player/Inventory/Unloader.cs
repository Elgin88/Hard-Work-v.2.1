using System.Collections;
using UnityEngine;
using HardWork;

namespace HardWork
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