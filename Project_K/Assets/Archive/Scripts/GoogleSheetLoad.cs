using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// DataBase
/// </summary>
public class GoogleSheetLoad : DontDestroySIngleton<GoogleSheetLoad>
{
    string getSheetData = "";

    private IEnumerator Start()
    {
        string googleSheetURL = GlobalVal.GetGoogleSheetAddress("https://docs.google.com/spreadsheets/d/1jBtwF2mr6BvDl31bHpLFDKxFao3YKvJjy4sZYgctgUA", "A2:C3", "0");

        using (UnityWebRequest www = UnityWebRequest.Get(googleSheetURL))
        {
            // 서버로부터 값을 받아옴
            yield return www.SendWebRequest();

            // 완료 되지 않았다면 대기
            while (!www.isDone)
            {
                yield return null;
            }
            

            if (www.isDone)
                getSheetData = www.downloadHandler.text;
        }

        
        DisplayText();
    }

    void DisplayText()
    {
        Debug.Log(getSheetData);

        string[] rows = getSheetData.Split('\n');
        string[] columns = rows[0].Split('\t');

    }

}
