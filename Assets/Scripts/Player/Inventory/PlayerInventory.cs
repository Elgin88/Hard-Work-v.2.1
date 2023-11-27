using System;
using System.Collections.Generic;
using UnityEngine;

namespace HardWork
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<LineOfPoints> _lines;
        [SerializeField] private LineOfPointsCreater _lineOfPointsCreater;

        private bool _isFull = false;
        private bool _isMoveBlocksToPlayer = false;
        private bool _isMoveBlocksToCollector = false;

        public Action <int, int> NumberBlocksIsChanged;

        public int GetNumberLines => _lines.Count;

        public bool IsMoveBlocksToPlayer => _isMoveBlocksToPlayer;

        public bool IsMoveBlocksToCollector => _isMoveBlocksToCollector;

        public void SetTrueIsMoveBlocksToPlayer()
        {
            _isMoveBlocksToPlayer = true;
        }

        public void SetFalseIsMoveBlocksToPlayer()
        {
            _isMoveBlocksToPlayer = false;
        }

        public void SetTrueIsMoveBlocksToCollector()
        {
            _isMoveBlocksToCollector = true;
        }

        public void SetFalseIsMoveBlocksToCollector()
        {
            _isMoveBlocksToCollector = false;
        }

        public void CreateLine()
        {
            _lineOfPointsCreater.CreateLine();
        }

        public void AddLine(LineOfPoints line)
        {
            _lines.Add(line);
        }

        public int GetCountOfLines()
        {
            return _lines.Count;
        }

        public Point TakePoint()
        {
            if (CheckIsFull() == true)
            {
                CreateLine();
            }

            if (CheckIsFull() == false)
            {
                foreach (LineOfPoints line in _lines)
                {
                    Point point = line.TakePoint();

                    if (point != null)
                    {
                        return point;
                    }
                }
            }

            return null;
        }

        public bool CheckIsFull()
        {
            foreach (LineOfPoints line in _lines)
            {
                if (line.CheckIsFull() == false)
                {
                    _isFull = false;
                    return _isFull;
                }
            }

            _isFull = true;
            return _isFull;
        }

        public Block GetLastAddBlock()
        {
            return _lines[_lines.Count - 1].GetLastAddBlockInLine();
        }

        public void RemoveTopLine()
        {
            GameObject lineToDestroy = _lines[_lines.Count - 1].gameObject;

            _lines.Remove(_lines[_lines.Count - 1]);
            Destroy(lineToDestroy);
        }

        public int GetNumberBloksInTopLine()
        {
            return _lines[_lines.Count - 1].GetNumberOfBlocks();
        }

        public int GetCurrentCountOfBlocks()
        {
            int currentCountOfBlocks = 0;

            foreach (LineOfPoints line in _lines)
            {
                currentCountOfBlocks += line.GetNumberOfBlocks();
            }

            return currentCountOfBlocks;
        }

        public int GetMaxCountOfBlocks()
        {
            return _lineOfPointsCreater.MaxNumberOfLines * _lines[0].GetNumberOfPoints();
        }

        public void InitEventBlockIsChanged()
        {
            NumberBlocksIsChanged?.Invoke(GetCurrentCountOfBlocks(), GetMaxCountOfBlocks());
        }

        private void OnEnable()
        {
            _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
        }
    }
}