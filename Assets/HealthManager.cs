using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 2f;

    private Animator _anim;
    private ParticleSystem _explosionFX;
    private ParticleSystem _simpleExplosionFX;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _explosionFX = Resources.Load<ParticleSystem>("Particles/SpaceExplosion");
        _simpleExplosionFX = Resources.Load<ParticleSystem>("Particles/SimpleExplosionFX");
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(_explosionFX, transform.position, Quaternion.identity);
            Instantiate(_simpleExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Hit(float damage)
    {
        _anim.Play("Hit");
        health -= damage;
    }

}
