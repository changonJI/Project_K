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

        // 시트 URL을 가져온뒤 해당 Data Type으로 테이블 Manager들 호출
        yield return LoadSheetURLData();

        if (dic_Url.Count < 0)
        {
            Debug.LogError("Sheet에 URL 경로 없어서 강제 종료");

            Application.Quit();
            yield break;
        }

        // IEnumerable로 return 받아서 foreach문 사용이 가능하다.
        var datas = Utils.GetAllInterface<IDataManager>();
        foreach (var data in datas)
        {
            // Generic 인자(SIngleTon<>으로 가져와야 Instance Proper)를 가진 타입을 생성
            // Type.MakeGenericType(Type)
            var geneticType = typeof(Singleton<>).MakeGenericType(data);
            // Type의 Property를 가져오는 방법
            // Type.GetProperty(해당 프로퍼티 명)
            //var property = geneticType.GetProperty(nameof(Singleton<object>.Instance));
            var property = geneticType.GetProperty("Instance");
            // Instance 호출
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

        // 다 받은 뒤 clear
        dic_Url.Clear();
    }

    public IEnumerator LoadSheetURLData()
    {
        // 각 테이블의 주소값 
        using (UnityWebRequest www = UnityWebRequest.Get(str_sheetUrl))
        {
            // 이 시간을 초과하면 중단
            www.timeout = 60;

            // 서버로부터 값을 받아옴
            yield return www.SendWebRequest();

            // 완료 되지 않았다면 대기
            while (!www.isDone)
            {
                yield return null;
            }

            // 에러가 났다면 에러메시지 출력 후 break;
            if (www.error != null)
            {
                Debug.LogError(www.error);
                Debug.LogError("앱 강제 종료");

                Application.Quit();
                yield break;
            }

            // 테이블 데이터 저장
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
        // 각 테이블의 주소값 
        using (UnityWebRequest www = UnityWebRequest.Get(Url))
        {
            // 이 시간을 초과하면 중단
            www.timeout = 60;

            // 서버로부터 값을 받아옴
            yield return www.SendWebRequest();

            // 완료 되지 않았다면 대기
            while (!www.isDone)
            {
                yield return null;
            }

            // 에러가 났다면 에러메시지 출력 후 break;
            if (www.error != null)
            {
                Debug.LogError(www.error);
                Debug.LogError("앱 강제 종료");

                Application.Quit();
                yield break;
            }

            // 테이블 데이터 저장
            if (www.isDone)
            {
                instance.LoadData(www.downloadHandler.text);
            }
        }
    }
}
