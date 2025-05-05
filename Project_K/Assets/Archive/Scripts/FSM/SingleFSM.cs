using System.Collections.Generic;
using UnityEngine;

public class SingleFSM<T> : FSM<T> where T : Object
{
    // 상태 되돌리기 용
    private Stack<ChangeStateInfo> stateInfoStack = new Stack<ChangeStateInfo>();
    private bool IsRunRollBack = false;
    private bool UsedRollBack = false;

    // 현재 상태
    public FiniteState<T> curState
    {
        get; protected set;
    }

    // 다음 상태
    public FiniteState<T> nextState
    {
        get; protected set;
    }

    // 모든 상태
    public List<FiniteState<T>> StoredStates
    {
        get; protected set;
    }

    public bool isLog = false;

    public SingleFSM(T owner, bool rollback = false)
        : base(owner)
    {
        Owner = owner;
        StoredStates = new List<FiniteState<T>>();
        curState = null;
        nextState = null;
        UsedRollBack = rollback;
    }

    public override void Clear()
    {
        if(curState != null)
        {
            curState.OnExit();
            curState = null;
        }

        nextState = null;
    }

    public override void Update()
    {
        ChangeState();
    }

    private void ChangeState()
    {
        if(nextState != null)
        {
            ChangeRemoveStates();
            ChangeAddStates();
        }
    }

    #region ChangeState()
    private void ChangeRemoveStates()
    {
        if (curState != null)
        {
            if (!IsRunRollBack && UsedRollBack)
            {
                stateInfoStack.Push(curState.newChangeStateInfo());
            }

            curState.OnExit();
            StoredStates.Add(curState);
        }
    }

    private void ChangeAddStates()
    {
        curState = nextState;
        nextState = null;
        if (curState.isOnEnter)
        {
            curState.OnEnter();
        }

        curState.OnReset();
        IsRunRollBack = false;
    }
    #endregion

    public override FiniteState<T> SetNextState(System.Type type, params object[] nextParams)
    {
        IsRunRollBack = false;
        return InternalSetNextState(type, nextParams);
    }

    private FiniteState<T> InternalSetNextState(System.Type type, params object[] nextParams)
    {
        return SetNextStateParams(type, nextParams);
    }

    private FiniteState<T> SetNextStateParams(System.Type type, params object[] nextParams)
    {
        FiniteState<T> state = GetState(type);
        if (state == null)
            Debug.LogError($"Not Found State. = {type.ToString()}");
        else
        {
            nextState = state;
            state.SetParams(nextParams);
        }

        return state;
    }

    private FiniteState<T> GetState(System.Type type)
    {
        for (int i = 0; i < StoredStates.Count; i++)
        {
            var state = StoredStates[i];
            if (state.GetType() == type)
            {
                StoredStates.Remove(state);
                return state;
            }
        }

        if (nextState != null)
        {
            var state = nextState;
            if (nextState.GetType() == type)
            {
                nextState = null;
                return state;
            }
        }

        FiniteState<T> createState = (FiniteState<T>)System.Activator.CreateInstance(type);
        createState?.Init(this);

        return createState;
    }
}