using System;
using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedState : MonoBehaviour
{
    private HealthContainer _healthContainer;
    private PlayerStateMachine _player;
    private RotatorState _rotator;

    private void Awake()
    {
        _healthContainer = GetComponent<HealthContainer>();
        _player = GetComponent<PlayerStateMachine>();
        _rotator = GetComponent<RotatorState>();
    }

    private void OnEnable() => _healthContainer.Died += OnDied;

    private void OnDisable() => _healthContainer.Died -= OnDied;

    private void OnDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _healthContainer.enabled = false;
        _player.enabled = false;
        _rotator.enabled = false;
    }
}