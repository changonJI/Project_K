using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ���̺���� ��ӹ޾ƾ� �ϴ� �������̽�
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
