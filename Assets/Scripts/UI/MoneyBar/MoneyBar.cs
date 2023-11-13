using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        if (_moneyCount == null || _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _canvasUI.Player.IsMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _canvasUI.Player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}