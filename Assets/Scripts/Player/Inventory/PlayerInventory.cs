using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<LineOfPoints> _lines;
    [SerializeField] private LineOfPointsCreater _lineOfPointsCreater;

    private bool _isFull = false;

    public int GetNumberLines => _lines.Count;
    public Action <int,int> IsChangedNumberBlocks;

    private void Start()
    {
        if (_lines == null || _lineOfPointsCreater == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
    }

    public void TryCreateLine()
    {
        _lineOfPointsCreater.TryCreateLine();
    }

    public void AddLine(LineOfPoints line)
    {
        _lines.Add(line);
    }

    public int GetCountOfLines()
    {
        return _lines.Count;
    }

    public Point TryTakePoint()
    {
        if (CheckIsFull() == true)
        {
            TryCreateLine();
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

    public Block TryGetLastAddBlock()
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
        IsChangedNumberBlocks?.Invoke(GetCurrentCountOfBlocks(), GetMaxCountOfBlocks());
    }
}