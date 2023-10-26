using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerDestroyerTakeDamagePoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _particle;

    private WaitForSeconds _pauseWFS;
    private Coroutine _pause;

    private void OnEnable()
    {
        if (_particle!=null)
        {
            _particle.gameObject.SetActive(false);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block) || collision.gameObject.TryGetComponent<SectionOfBlocks>(out SectionOfBlocks section))
        {
            _particle.gameObject.SetActive(true);
            _particle.Play();
            _player.SoundController.PlayBlockHitBumberSound();
        }
    }    
}