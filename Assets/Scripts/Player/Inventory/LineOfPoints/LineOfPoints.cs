using System.Collections.Generic;
using HardWork.Block;
using UnityEngine;

namespace HardWork.Player
{
    public class LineOfPoints : MonoBehaviour
    {
        [SerializeField] private List<Point> _points;

        private bool _isFull = false;

        public int NumberPoints => _points.Count;

        public Point TakePoint()
        {
            foreach (Point point in _points)
            {
                if (point.Block == false)
                {
                    point.Take();
                    return point;
                }
            }

            return null;
        }

        public bool CheckIsFull()
        {
            foreach (Point point in _points)
            {
                if (point.Block == false)
                {
                    _isFull = false;
                    return _isFull;
                }
            }

            _isFull = true;
            return _isFull;
        }

        public void MoveUp(float deltaBetweenBlocks)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + deltaBetweenBlocks, transform.position.z);
        }

        public BlockMain GetLastAddBlockInLine()
        {
            BlockMain lastAddBlock = null;

            foreach (Point point in _points)
            {
                if (point.Block)
                {
                    lastAddBlock = point.Block;
                }
            }

            return lastAddBlock;
        }

        public void RemoveLine()
        {
            Destroy(gameObject);
        }

        public int GetNumberOfBlocks()
        {
            int numberOfBlocks = 0;

            foreach (Point point in _points)
            {
                if (point.Block != null)
                {
                    numberOfBlocks++;
                }
            }

            return numberOfBlocks;
        }

        public int GetNumberOfPoints()
        {
            return _points.Count;
        }
    }
}