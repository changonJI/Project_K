using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// DataBase
/// </summary>
public class GoogleSheetLoad : Singleton<GoogleSheetLoad>
{
    //public string googleSheetURL = Utils.GetGoogleSheetAddress("https://docs.google.com/spreadsheets/d/1jBtwF2mr6BvDl31bHpLFDKxFao3YKvJjy4sZYgctgUA", "A2:C3", "0");
    private string str_sheetUrl = "";
    private Dictionary<eTable_Type, GoogleSheetUrl> dic_Url = new Dictionary<eTable_Type, GoogleSheetUrl>();

    public IEnumerator LoadData(string sheetUrl)
    {
        str_sheetUrl = sheetUrl;

        // ��Ʈ URL�� �����µ� �ش� Data Type���� ���̺� Manager�� ȣ��
        yield return LoadSheetURLData();

        if (dic_Url.Count < 0)
        {
            Debug.LogError("Sheet�� URL ��� ��� ���� ����");

            Application.Quit();
            yield break;
        }

        // IEnumerable�� return �޾Ƽ� foreach�� ����� �����ϴ�.
        var datas = Utils.GetAllInterface<IDataManager>();
        foreach (var data in datas)
        {
            // Generic ����(SIngleTon<>���� �����;� Instance Proper)�� ���� Ÿ���� ����
            // Type.MakeGenericType(Type)
            var geneticType = typeof(Singleton<>).MakeGenericType(data);
            // Type�� Property�� �������� ���
            // Type.GetProperty(�ش� ������Ƽ ��)
            //var property = geneticType.GetProperty(nameof(Singleton<object>.Instance));
            var property = geneticType.GetProperty("Instance");
            // Instance ȣ��
            IDataManager instance = (IDataManager)property.GetValue(null);
            instance.ClearData();

            if (dic_Url.ContainsKey(instance.table_Type))
            {
                string url = Utils.GetGoogleSheetAddress(dic_Url[instance.table_Type].str_address,
                                                         dic_Url[instance.table_Type].str_range,
                                                         dic_Url[instance.table_Type].str_SheetID);
                yield return LoadTableData(url, instance);
            }
        }

        // �� ���� �� clear
        dic_Url.Clear();
    }

    public IEnumerator LoadSheetURLData()
    {
        // �� ���̺��� �ּҰ� 
        using (UnityWebRequest www = UnityWebRequest.Get(str_sheetUrl))
        {
            // �� �ð��� �ʰ��ϸ� �ߴ�
            www.timeout = 60;

            // �����κ��� ���� �޾ƿ�
            yield return www.SendWebRequest();

            // �Ϸ� ���� �ʾҴٸ� ���
            while (!www.isDone)
            {
                yield return null;
            }

            // ������ ���ٸ� �����޽��� ��� �� break;
            if (www.error != null)
            {
                Debug.LogError(www.error);
                Debug.LogError("�� ���� ����");

                Application.Quit();
                yield break;
            }

            // ���̺� ������ ����
            if (www.isDone)
            {
                string Urls = www.downloadHandler.text;

                string[] rows = Urls.Split('\n');

                for (int i = 0; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split('\t');
                    GoogleSheetUrl data = new GoogleSheetUrl(columns.ToList());

                    if (!dic_Url.ContainsKey(data.str_type))
                    {
                        dic_Url.Add(data.str_type, data);
                    }
                }
            }
        }
    }

    public IEnumerator LoadTableData(string Url, IDataManager instance)
    {
        // �� ���̺��� �ּҰ� 
        using (UnityWebRequest www = UnityWebRequest.Get(Url))
        {
            // �� �ð��� �ʰ��ϸ� �ߴ�
            www.timeout = 60;

            // �����κ��� ���� �޾ƿ�
            yield return www.SendWebRequest();

            // �Ϸ� ���� �ʾҴٸ� ���
            while (!www.isDone)
            {
                yield return null;
            }

            // ������ ���ٸ� �����޽��� ��� �� break;
            if (www.error != null)
            {
                Debug.LogError(www.error);
                Debug.LogError("�� ���� ����");

                Application.Quit();
                yield break;
            }

            // ���̺� ������ ����
            if (www.isDone)
            {
                instance.LoadData(www.downloadHandler.text);
            }
        }
    }
}
