using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetLoad : MonoBehaviour
{
    // �����ؿ� URL : https://docs.google.com/spreadsheets/d/1jBtwF2mr6BvDl31bHpLFDKxFao3YKvJjy4sZYgctgUA/edit?usp=sharing
    // edit?usp=sharing ����
    // ���ŵ� �κп� export?format=tsv&range=��Ʈ ����

    const string googleSheetURL = "https://docs.google.com/spreadsheets/d/1jBtwF2mr6BvDl31bHpLFDKxFao3YKvJjy4sZYgctgUA/export?format=tsv&range=A2:C2";
    string getSheetData = "";

    private IEnumerator Start()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(googleSheetURL))
        {
            yield return www.SendWebRequest();

            if (www.isDone)
                getSheetData = www.downloadHandler.text;

        }

        DisplayText();
    }

    void DisplayText()
    {
        string[] rows = getSheetData.Split('\n');
        string[] columns = rows[0].Split('\t');

        //Debug.Log(columns[1]);
    }

}
