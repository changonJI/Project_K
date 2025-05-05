using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : GameUnit
{
    public GameObject go_PlayerUnit;

    private Vector3 vec_TargetPos;

    private void Awake()
    {
        // 아바타 모델 생성이후 스텟 세팅

        // 스텟 설정

        // inputManager를 추가하기.
        // InputManager에 컨트롤러, 마우스 클릭등을 적용
        // Player만 갖고있음.


    }

    //public override void Move()
    //{
    //    if (go_PlayerUnit != null)
    //        go_PlayerUnit.transform.position = vec_TargetPos;
    //}

    //public override void Hit()
    //{

    //}

    //public override void Speak()
    //{

    //}


    //private void Update()
    //{
    //    var xMove = Input.GetAxis("Horizontal");
    //    var zMove = Input.GetAxis("Vertical");

    //    var targetX = go_PlayerUnit.transform.localPosition.x + (xMove * Time.deltaTime);
    //    var targetZ = go_PlayerUnit.transform.localPosition.z + (zMove * Time.deltaTime);

    //    vec_TargetPos = new Vector3(targetX, 0, targetZ);
        
    //    Move();
        
    //}
}
