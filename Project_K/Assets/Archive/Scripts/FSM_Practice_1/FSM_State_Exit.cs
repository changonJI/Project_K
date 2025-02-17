using UnityEngine;

public class FSM_State_Exit : FSM_State
{
    public void Enter()
    {
        Debug.Log($"{nameof(FSM_State_Exit)} Enter");
    }

    public void Exit()
    {
        Debug.Log($"{nameof(FSM_State_Exit)} Exit");
    }

    public void Runnig()
    {
        Debug.Log($"{nameof(FSM_State_Exit)} Runnig");
    }


}
