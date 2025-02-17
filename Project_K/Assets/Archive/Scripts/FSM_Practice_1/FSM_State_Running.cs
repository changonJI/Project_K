using UnityEngine;

public class FSM_State_Running : FSM_State
{
    public void Enter()
    {
        Debug.Log($"{nameof(FSM_State_Running)} Enter");
    }

    public void Exit()
    {
        Debug.Log($"{nameof(FSM_State_Running)} Exit");
    }

    public void Runnig()
    {
        Debug.Log($"{nameof(FSM_State_Running)} Runnig");
    }


}
