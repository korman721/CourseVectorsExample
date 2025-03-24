using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;

    private float _time;
    private float _damagePerSecond = 1;
    private float _timeBetweenDamageTicks = 0.1f;

    private float _damagePerTick;

    private void Awake()
    {
        _damagePerTick = _damagePerSecond * _timeBetweenDamageTicks;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _collisionEffect.Play();

            TakeDamageTo(rocket);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time += Time.deltaTime;

            ContactPoint firstContact = collision.contacts[0];

            _collisionEffect.transform.position = firstContact.point;
            _collisionEffect.transform.rotation = Quaternion.LookRotation(-firstContact.normal);

            if (_time > _timeBetweenDamageTicks)
            {
                TakeDamageTo(rocket);

                _time = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _collisionEffect.Stop();
            _time = 0;
        }
    }

    private void TakeDamageTo(Rocket rocket)
    {
        rocket.TakeDamage(_damagePerTick);

        if (rocket.CurrentHealth <= 0)
            _collisionEffect.Stop();
    }
}
