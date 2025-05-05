using UnityEngine;

/// <summary>
/// 변경 상태 정보
/// </summary>
public class ChangeStateInfo
{
    public object[] stateParams;
    public System.Type stateType;
    public ChangeStateInfo(System.Type stateType, params object[] ps)
    {
        this.stateType = stateType;
        stateParams = ps;
    }
}

//NOTE:  Object 클래스
//GameObject, Component, Material, Texture, Mesh, Sprite 등을 비롯한 대부분의 Unity 빌트인 클래스에 대한 기본 클래스 역할
/// <summary>
/// 유한상태머신 제네릭 클래스. Multi와 Single로 나뉜다.
/// </summary>
/// <typeparam name="T"></typeparam>
public class FSM<T> where T : Object
{

    /// <summary>
    /// FSM Owner
    /// </summary>
    public T Owner
    {
        get; protected set;
    }

    /// <summary>
    /// FSM 생성자
    /// </summary>
    /// <param name="owner"></param>
    public FSM(T owner)
    {
        Owner = owner;
    }

    // 초기화
    public virtual void Clear() {}

    // 프레임 단위
    public virtual void Update() {}
    public virtual void LateUpdate() {}
    public virtual void FixedUpdate() {}
    public virtual void DrawGizmos() {}
    public virtual void GUI() {}

    // 상태 변경
    public virtual FiniteState<T> SetNextState(System.Type type, params object[] nextParams) { return null; }

    // 상태 제거
    public virtual void SetRemoveState(FiniteState<T> state, bool isWarring = true) { Debug.LogError("unexpected error"); }
    public virtual void SetRemoveState(System.Type type, bool isWarring = true) { Debug.LogError("unexpected error"); }

    // 상태 추가
    public virtual void AddState(FiniteState<T> state) {}

    // 상태 출력
    public FiniteState<T> GetCurState(System.Type type) { return null; }

    // 상태 체크
    public virtual bool IsCurState(System.Type type)
    {
        return false;
    }
    public virtual bool IsNextState(System.Type type)
    {
        return false;
    }
    public virtual bool IsPrevState(System.Type type)
    {
        return false;
    }

    // 이전 상태 복원
    public virtual bool RoolBack(bool Immediatly = false)
    {
        return false; 
    }


}
