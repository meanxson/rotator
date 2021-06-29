using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damage;
    public int Health { get; private set; } = 20;
    public int Damage => _damage;
    public UnityAction Died;

    public PlayerStateMachine PlayerMachine { get; private set; }

    private void Awake() => PlayerMachine = GetComponent<PlayerStateMachine>();

    public void ApplyDamage(int damage)
    {
        if (Health > 0)
            Health -= damage;
        else
        {
            Died?.Invoke();
            _damage = 0;
        }
    }
}