using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveState), typeof(EnemyDoesNotMoveState))]
public class EnemyState : MonoBehaviour
{
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    private void Awake()
    {
        InitState();
        SetDefaultState();
    }

    private void InitState()
    {
        _states = new Dictionary<Type, IState>();

        _states[typeof(EnemyMoveState)] = GetComponent<EnemyMoveState>();
        _states[typeof(EnemyDoesNotMoveState)] = GetComponent<EnemyDoesNotMoveState>();
    }

    private void SetState(IState state)
    {
        if (_currentState == state)
            return;

        if (_currentState != null)
            _currentState.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }

    private void SetDefaultState()
    {
        SetDoesNotMoveState();
    }

    private IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _states[type];
    }

    public void SetMoveState()
    {
        var state = GetState<EnemyMoveState>();
        SetState(state);
    }

    public void SetDoesNotMoveState()
    {
        var state = GetState<EnemyDoesNotMoveState>();
        SetState(state);
    }
}
