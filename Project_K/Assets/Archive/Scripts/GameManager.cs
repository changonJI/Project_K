using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� �Ŵ����� ����ִ� Ŭ����.
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

        // ���̺� �ε�
        //InitTableData();
        // ���¹��� �ε�
    }

    private IEnumerator Start()
    {
        StartCoroutine(GoogleSheetLoad.Instance.LoadData(Utils.GetGoogleSheetAddress(str_Url,str_Range,str_SheetID)));

        yield return new WaitForSeconds(1f);
    }
}
