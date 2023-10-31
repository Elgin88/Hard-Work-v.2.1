using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Player _player;

    public Player Player => _player;

    private void Start()
    {
        if (_player == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}
