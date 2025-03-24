using UnityEngine;

public class Rocket : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private KeyCode LaunchKey = KeyCode.Space;

    private Rigidbody _rigidbody;

    [SerializeField] private float _force;
    [SerializeField] private float _rotationForce;

    [SerializeField] private ParticleSystem _deathEffect;

    private int _coins;

    private float _xInput;
    private bool _isLaunched;

    private float _deadZone = 0.05f;

    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxis);
        _isLaunched = Input.GetKey(LaunchKey);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
        {
            _rigidbody.AddRelativeTorque(Vector3.back * _rotationForce * _xInput);
        }

        if (_isLaunched)
        {
            _rigidbody.AddForce(transform.up * _force);
        }
    }

    public void AddCoin(int value)
    {
        _coins += value;

        Debug.Log(_coins);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _currentHealth = 0;

        _deathEffect.transform.position = transform.position;
        _deathEffect.Play();

        gameObject.SetActive(false);
        Debug.Log("You Die");
    }
}
