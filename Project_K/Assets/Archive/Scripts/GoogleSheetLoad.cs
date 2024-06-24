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
            // �����κ��� ���� �޾ƿ�
            yield return www.SendWebRequest();

            // �Ϸ� ���� �ʾҴٸ� ���
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
