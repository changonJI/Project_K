using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 테이블들이 상속받아야 하는 인터페이스
/// </summary>
public interface IDataManager
{
    eTable_Type table_Type
    {
        get;
    }

    void ClearData();
    void LoadData(string str_Data);
}
