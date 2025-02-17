using UnityEngine;

public class FSM_State_Idle : FSM_State
{
    public void Enter()
    {
        Debug.Log($"{nameof(FSM_State_Idle)} Enter");
    }

    public void Exit()
    {
        Debug.Log($"{nameof(FSM_State_Idle)} Exit");
    }

    public void Runnig()
    {
        Debug.Log($"{nameof(FSM_State_Idle)} Runnig");
    }


}
