using HardWork.Block;
using UnityEngine;

namespace HardWork.Player
{
    public class Point : MonoBehaviour
    {
        private BlockMain _block;

        public BlockMain Block => _block;

        public Point Take()
        {
            return this;
        }

        public void InitBlock(BlockMain block)
        {
            _block = block;
        }

        public void RemoveBlock()
        {
            _block = null;
        }
    }
}