using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoData : IData
{
    public readonly int id;
    public readonly string itemName;
    public readonly string itemDesc;

    public ItemInfoData()
    {
        id = 0;
        itemName = "";
        itemDesc = "";
    }

    public ItemInfoData(List<string> list_Data)
    {
        int count = -1;

        id = int.Parse(list_Data[++count]);
        itemName = list_Data[++count];
        itemDesc = list_Data[++count];
    }

}
