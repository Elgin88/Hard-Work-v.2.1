using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        if (_label == null || _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _label.text = _canvasUI.CalculatorBlocks.Unload.ToString();
    }
}