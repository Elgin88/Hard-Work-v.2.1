using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Coroutine _rotate;

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(1,1,1);



            yield return null;
        }
    }

    public void StartRotate()
    {
        if (_rotate == null)
        {
            _rotate = StartCoroutine(Rotate());
        }
    }

    public void StopRotate()
    {
        if (_rotate != null)
        {
            StopCoroutine(_rotate);
            _rotate = null;
        }
    }
}
