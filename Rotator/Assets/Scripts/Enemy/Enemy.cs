using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _healthPoint;
    [SerializeField] private int _damage;

    private EnemyMover _mover;

    private void Awake() => _mover = GetComponent<EnemyMover>();

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out HealthContainer healthContainer))
        {
            switch (healthContainer.PlayerMachine.State)
            {
                case PlayerState.Rotate:
                    ApplyDamage(healthContainer.Damage);
                    break;
                case PlayerState.Idle:
                    healthContainer.ApplyDamage(_damage);
                    break;
                case PlayerState.Died:
                    _mover.enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void Update()
    {
        if (_healthPoint <= 0)
            Die();
    }

    public void ApplyDamage(int damage)
    {
        if (_healthPoint > 0)
            _healthPoint -= damage;
    }

    private void Die() => Destroy(gameObject);
}