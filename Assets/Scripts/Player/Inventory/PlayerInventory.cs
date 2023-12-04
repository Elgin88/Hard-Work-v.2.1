using System;
using System.Collections.Generic;
using HardWork.Block;
using UnityEngine;

namespace HardWork.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<LineOfPoints> _lines;
        [SerializeField] private LineOfPointsCreater _lineOfPointsCreater;

        private List<BlockMain> _blocksMovingToPlayer;
        private List<BlockMain> _blocksMovingToCollector;

        public Action<int, int> NumberBlocksIsChanged;

        public int GetNumberLines => _lines.Count;

        public int CountOfBlocksMovingToPlayer => _blocksMovingToPlayer.Count;

        public int CountOfBlocksMovingToCollector => _blocksMovingToCollector.Count;

        public void AddBlockMovingToPlayer(BlockMain block)
        {
            _blocksMovingToPlayer.Add(block);
        }

        public void RemoveBlockMovingToPlayer(BlockMain block)
        {
            _blocksMovingToPlayer.Remove(block);
        }

        public void AddBlockMovingToCollector(BlockMain block)
        {
            _blocksMovingToCollector.Add(block);
        }

        public void RemoveBlockMovingToCollector(BlockMain block)
        {
            _blocksMovingToCollector.Remove(block);
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
                    return false;
                }
            }

            return true;
        }

        public BlockMain GetLastAddBlock()
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

        private void Start()
        {
            _blocksMovingToPlayer = new List<BlockMain>();
            _blocksMovingToCollector = new List<BlockMain>();
        }
    }
}