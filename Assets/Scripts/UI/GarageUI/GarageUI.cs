using System.Collections;
using UnityEngine;

public class GarageUI : MonoBehaviour
{
    [SerializeField] private float _rangeToClosePanel;
    [SerializeField] private UIRequireComponents _UIRequireComponents;
    
    private Coroutine _checkDistance;

    private void Start()
    {
        if ( _rangeToClosePanel == 0 || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        StartCheckDistance();
    }

    private void OnDisable()
    {
        StopCheckDistance();
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            if (Vector3.Distance(_UIRequireComponents.DestroyerPoint.transform.position, _UIRequireComponents.GarageParkingArea.transform.position) > _rangeToClosePanel)
            {
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void StartCheckDistance()
    {
        if (_checkDistance == null)
        {
            _checkDistance = StartCoroutine(CheckDistance());
        }
    }

    private void StopCheckDistance()
    {
        if (_checkDistance != null)
        {
            StopCoroutine(_checkDistance);
            _checkDistance = null;
        }
    }
}