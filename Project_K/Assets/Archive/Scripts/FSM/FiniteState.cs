using UnityEngine;

public class FiniteState<T> where T : Object
{
    public bool isOnEnter = true;

    public object[] stateParams = null;
    protected FSM<T> machine = null;

    public ChangeStateInfo newChangeStateInfo() => new ChangeStateInfo(GetType(), stateParams);

    public virtual void Init(FSM<T> machine) => this.machine = machine;

    public virtual void SetParams(params object[] stateParams) => this.stateParams = stateParams;

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
        stateParams = null;
    }

    public virtual void OnReset() => isOnEnter = true;
}
