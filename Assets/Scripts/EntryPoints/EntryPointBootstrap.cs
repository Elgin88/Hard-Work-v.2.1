using UnityEngine;

public class EntryPointBootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _SDK;

    private void Start()
    {
        if (_SDK == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        InitSDK();
    }

    private void InitSDK()
    {
        _SDK.gameObject.SetActive(true);
    }
}