using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Unloader _unloader;
    [SerializeField] private Player _player;

    public Unloader Unloader => _unloader;
    public Player Player => _player;

    private void Start()
    {
        if (_unloader == null || _player == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}