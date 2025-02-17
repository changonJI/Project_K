using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FSMMain_Practice_1 : MonoBehaviour
{
    FSM_Practice_1 fsm;
    FSM_State_Idle idleState;
    FSM_State_Running RunningState;
    FSM_State_Exit ExitState;

    [SerializeField] TextMeshProUGUI text_curState;
    [SerializeField] Button btn_Idle;
    [SerializeField] Button btn_Running;
    [SerializeField] Button btn_Exit;

    private void Awake()
    {
        fsm = new FSM_Practice_1();
        idleState = new FSM_State_Idle();
        RunningState = new FSM_State_Running();
        ExitState = new FSM_State_Exit();

        btn_Idle.onClick.AddListener(() => OnClickState(idleState));
        btn_Running.onClick.AddListener(() => OnClickState(RunningState));
        btn_Exit.onClick.AddListener(() => OnClickState(ExitState));
    }

    private void Start()
    {
        //fsm.ChangeState(idleState);
    }

    private void OnClickState(FSM_State state)
    {
        fsm.ChangeState(state);
    }

    void Update()
    {
        text_curState.text = fsm.curState?.ToString() ?? "";
    }
}
