using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveState), typeof(PlayerDoesNotMoveState))]
public class PlayerState : MonoBehaviour
{
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    private void Start()
    {
        InitState();
        SetDefaultState();
    }

    private void InitState()
    {
        _states = new Dictionary<Type, IState>();

        _states[typeof(PlayerMoveState)] = GetComponent<PlayerMoveState>();
        _states[typeof(PlayerDoesNotMoveState)] = GetComponent<PlayerDoesNotMoveState>();
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
        var state = GetState<PlayerMoveState>();
        SetState(state);
    }

    public void SetDoesNotMoveState()
    {
        var state = GetState<PlayerDoesNotMoveState>();
        SetState(state);
    }
}