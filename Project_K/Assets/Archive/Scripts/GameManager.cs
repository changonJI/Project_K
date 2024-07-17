using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 매니저를 들고있는 클래스.
/// 
/// </summary>
public class GameManager : DontDestroySIngleton<GameManager>
{
    [Header("== GoogleSheetUrl ==")]
    [SerializeField] private string str_Url;
    [SerializeField] private string str_Range;
    [SerializeField] private string str_SheetID;

    protected override void Awake()
    {
        base.Awake();

        // 테이블 로드
        //InitTableData();
        // 에셋번들 로드
    }

    private IEnumerator Start()
    {
        StartCoroutine(GoogleSheetLoad.Instance.LoadData(Utils.GetGoogleSheetAddress(str_Url,str_Range,str_SheetID)));

        yield return new WaitForSeconds(1f);
    }
}
