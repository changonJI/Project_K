using System.Collections.Generic;
using UnityEngine;

public class MultiFSM<T> : FSM<T> where T : Object
{
    public readonly List<FiniteState<T>> curState = new List<FiniteState<T>>();
    public readonly List<FiniteState<T>> curTempState = new List<FiniteState<T>>();
    public readonly List<FiniteState<T>> nextState = new List<FiniteState<T>>();
    public readonly List<FiniteState<T>> nextTempState = new List<FiniteState<T>>();
    public readonly List<FiniteState<T>> RemoveState = new List<FiniteState<T>>();
    public readonly List<FiniteState<T>> RemoveTempState = new List<FiniteState<T>>();

    public readonly List<FiniteState<T>> StoredState = new List<FiniteState<T>>();

    public MultiFSM(T owner) : base(owner)
    {
        Owner = owner;
    }

    public override void Clear()
    {
        // 각 state별 param 제거
        foreach (var state in curState)
            state.OnExit();
        // 파라미터 제거후 현재 state 저장
        StoredState.AddRange(curState);
        // 현재 stateList 초기화
        curState.Clear();
        // 다음 state 저장
        StoredState.AddRange(nextState);
        // 다음 state 초기화
        nextState.Clear();
        // 제거된 상태 초기화
        RemoveState.Clear();
    }

    public override void Update()
    {
        ChangeState();

    }

    public override void LateUpdate()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void DrawGizmos()
    {
    }

    public override void GUI()
    {
    }

    private void ChangeState()
    {
        ChangeRemoveState();
        ChangeAddState();
    }

    private void ChangeRemoveState()
    {
        if (RemoveState != null && RemoveState.Count > 0)
        {
            PreRemoveStates();
            RemoveStates();
        }
    }

    private void PreRemoveStates()
    {
        for (int i = 0; i < RemoveState.Count; ++i)
            curState.Remove(RemoveState[i]);
    }

    private void RemoveStates()
    {
        RemoveTempState.AddRange(RemoveState);
        RemoveState.Clear();
        for (int i = 0; i < RemoveTempState.Count; ++i)
            RemoveTempState[i].OnExit();
        StoredState.AddRange(RemoveTempState);
        RemoveTempState.Clear();
    }

    private void ChangeAddState()
    {
        if (nextState != null && nextState.Count > 0)
            AddState();
    }

    private void AddState()
    {
        nextTempState.AddRange(nextState);
        nextState.Clear();
        for (int i = 0; i < nextTempState.Count; ++i)
        {
            var state = nextTempState[i];
            curState.Add(state);
            if (state.isOnEnter)
                state.OnEnter();
            state.OnReset();
        }
        nextTempState.Clear();
    }
}
