using Stateless;
using UnityEngine;

[SelectionBase]
public class PlayerStateMachine : MonoBehaviour
{
    private StateMachine<PlayerState, PlayerTrigger> _playerStateMachine =
        new StateMachine<PlayerState, PlayerTrigger>(PlayerState.Idle);

    private Animator _animator;
    private RotatorState _rotator;
    private HealthContainer _healthContainer;
    private DiedState _diedState;
    
    public PlayerState State { get; private set; } = PlayerState.Idle;

    private void Awake()
    {
        StateConfigure();

        _animator = GetComponent<Animator>();
        _rotator = GetComponent<RotatorState>();
        _healthContainer = GetComponent<HealthContainer>();
        _diedState = GetComponent<DiedState>();
        _playerStateMachine.Fire(PlayerTrigger.StopRotate);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_rotator.enabled)
            _playerStateMachine.Fire(PlayerTrigger.StartRotate);

        if (Input.GetMouseButtonUp(0))
            _playerStateMachine.Fire(PlayerTrigger.StopRotate);

        if (_healthContainer.Health <= 0)
            _playerStateMachine.Fire(PlayerTrigger.LostHealthPoint);
    }

    private void StateConfigure()
    {
        _playerStateMachine.Configure(PlayerState.Idle)
            .Permit(PlayerTrigger.StartRotate, PlayerState.Rotate)
            .Permit(PlayerTrigger.LostHealthPoint, PlayerState.Died)
            .OnEntry(() =>
            {
                _rotator.enabled = false;
                State = PlayerState.Idle;
            }).Ignore(PlayerTrigger.StopRotate);

        _playerStateMachine.Configure(PlayerState.Rotate)
            .Permit(PlayerTrigger.StopRotate, PlayerState.Idle)
            .Permit(PlayerTrigger.LostHealthPoint, PlayerState.Died)
            .OnEntry(() =>
            {
                _rotator.enabled = true;
                State = PlayerState.Rotate;
            }).Ignore(PlayerTrigger.StartRotate);

        _playerStateMachine.Configure(PlayerState.Died)
            .OnEntry(() =>
            {
                State = PlayerState.Died;
                enabled = false;
            }).Ignore(PlayerTrigger.LostHealthPoint);
    }
}