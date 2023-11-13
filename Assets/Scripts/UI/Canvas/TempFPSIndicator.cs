using System.Collections;
using TMPro;
using UnityEngine;

public class TempFPSIndicator : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] private float _timeShowFPS;

    private Coroutine _showFPS;
    private WaitForSeconds _timeShowFPSWFS;

    private void Start()
    {
        if (_text == null|| _timeShowFPS == 0)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

        _timeShowFPSWFS = new WaitForSeconds(_timeShowFPS);

        _showFPS = StartCoroutine(ShowFPS());
    }

    private IEnumerator ShowFPS()
    {
        while (true)
        {
            _text.text = "FPS: " + (Mathf.Round(1 / Time.deltaTime)).ToString();

            yield return _timeShowFPSWFS;
        }
    }
}
