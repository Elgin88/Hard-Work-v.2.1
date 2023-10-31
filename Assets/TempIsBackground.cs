using TMPro;
using UnityEngine;

public class TempIsBackground : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private void Update()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        _tmpText.text = Agava.WebUtility.WebApplication.InBackground.ToString();
#endif
    }
}
