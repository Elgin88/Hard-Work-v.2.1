using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Unloader _unloader;
    [SerializeField] private PlayerRequireComponents _player;

    public Unloader Unloader => _unloader;
    public PlayerRequireComponents Player => _player;

    private void Start()
    {
        if (_unloader == null || _player == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}