using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] private ParticleSystem cubeExplosion;
    ParticleSystem.MainModule cubeExplosionMainModule;
    public static FX instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cubeExplosionMainModule = cubeExplosion.main;
    }
    public void PlayExplosionFX(Vector3 position, Color color)
    {
        cubeExplosionMainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeExplosion.transform.position = position;
        cubeExplosion.Play();

    }
}
