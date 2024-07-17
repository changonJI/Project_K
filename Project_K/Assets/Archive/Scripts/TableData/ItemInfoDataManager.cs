using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemInfoDataManager : Singleton<ItemInfoDataManager>, IDataManager
{
    public eTable_Type table_Type
    {
        get
        {
            return eTable_Type.ITEMINFO;
        }
    }

    private readonly Dictionary<int, ItemInfoData> dic_Data = new Dictionary<int, ItemInfoData>();

    public void ClearData()
    {
        dic_Data.Clear();
    }

    public void LoadData(string str_Data)
    {
        string[] rows = str_Data.Split('\n');
        
        for(int i = 0; i < rows.Length; i++)
        {
            string[] columns = rows[i].Split('\t');
            ItemInfoData data = new ItemInfoData(columns.ToList());

            if (!dic_Data.ContainsKey(data.id))
            {
                dic_Data.Add(data.id, data);
            }
        }
    }

    public ItemInfoData Get(int id)
    {
        if (id < 0) return null;

        if (dic_Data.ContainsKey(id))
        {
            return dic_Data[id];
        }
        else
        {
            Debug.LogError($"ItemInfoData에 해당 ID값의 데이터가 없습니다. ID : {id}");
            return null;
        }
    }

}
