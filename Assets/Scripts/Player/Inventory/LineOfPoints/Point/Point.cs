using UnityEngine;

namespace HardWork
{
    public class Point : MonoBehaviour
    {
        private Block _block;

        public Block Block => _block;

        public Point Take()
        {
            return this;
        }

        public void InitBlock(Block block)
        {
            _block = block;
        }

        public Block GetBlock()
        {
            return _block;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void RemoveBlock()
        {
            _block = null;
        }
    }
}