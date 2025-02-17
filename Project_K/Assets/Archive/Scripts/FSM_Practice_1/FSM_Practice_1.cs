
public class FSM_Practice_1
{
    public FSM_State curState { get; private set; }

    public void ChangeState(FSM_State nextState)
    {
        if(curState == nextState) return;

        curState?.Exit();
        curState = nextState;
        curState.Enter();
    }

    public void Update()
    {
        curState?.Runnig();
    }
}

