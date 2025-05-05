using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleManager : MonoBehaviour
{
    // 번들 다운 받을 서버의 주소(임시)
    private readonly string BundleURL = "https://drive.google.com/drive/folders/1UMj_2j4Dy_IzeQ4UBwv7ZYcTtJgNqWoL";
    
    // 번들의 version
    public uint version = 0;

    void Start()
    {
        LoadFromWeb();
    }

    public void LoadFromWeb()
    {
        StartCoroutine(LoadFromWebProcess());
    }

    private IEnumerator LoadFromWebProcess()
    {
        using (var www = UnityWebRequestAssetBundle.GetAssetBundle(BundleURL, version: 1, crc: 0))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                throw new Exception($"에셋번들 연결 오류 발생 : {www.error}");
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

            if (bundle == null)
            {
                Debug.LogError("bundle is null");
                yield break;
            }

            var prefab = bundle.LoadAsset<GameObject>("BundleTest_1");
            Instantiate(prefab);

            bundle.Unload(false);
        }
    }
}
