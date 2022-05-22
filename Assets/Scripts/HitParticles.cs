using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HitParticles : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, _particleSystem.main.duration);
    }
}
