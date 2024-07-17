using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleSheetUrl
{
    public readonly eTable_Type str_type;
    public readonly string str_address;
    public readonly string str_range;
    public readonly string str_SheetID;

    public GoogleSheetUrl()
    {
        str_type = eTable_Type.NONE;
        str_address = "";
        str_range = "";
        str_SheetID = "";
    }

    public GoogleSheetUrl(List<string> list_Data)
    {
        int count = -1;

        str_type = (eTable_Type)Enum.Parse(typeof(eTable_Type),list_Data[++count]);
        str_address = list_Data[++count];
        str_range = list_Data[++count];
        str_SheetID = list_Data[++count];
    }
}
