using UnityEngine;

public class UIStateManager : DontDestroySIngleton<UIStateManager>
{
    protected SingleFSM<UIStateManager> singleFSM;

    protected override void Awake()
    {
        base.Awake();
        singleFSM = new SingleFSM<UIStateManager>(this, true);
    }

    public void SetNextState(System.Type type, params object[] nextParams)
    {
        if(singleFSM != null)
        {
            singleFSM.SetNextState(type, nextParams);
        }
    }

    protected virtual void Update()
    {
        singleFSM.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnEvent(string msg)
    {
        if (msg == null)
        {
            return;
        }

        if(singleFSM != null)
        {

        }
    }

    public static void SendEventMessage(string msg, params object[] ps)
    {
        if (instance != null)
            instance.OnEvent(msg);
    }
}
