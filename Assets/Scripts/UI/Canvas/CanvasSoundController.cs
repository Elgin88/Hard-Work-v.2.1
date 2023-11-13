using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CanvasSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _buySound;

    private void Start()
    {
        if (_buySound == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    public void PlayBuySound()
    {
        _buySound.Play();
    }
}
