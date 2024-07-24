using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleManager : MonoBehaviour
{
    // 번들 다운 받을 서버의 주소
    private readonly string BundleURL = "https://drive.google.com/uc?export=download&id=1tY7mXdobHUE8adW0IQUFTdJ2OI-EsW6a";
    // 번들의 version
    private uint version = 0;

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
        var webRequest = UnityWebRequestAssetBundle.GetAssetBundle(BundleURL, version : 0, crc: 0);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(webRequest.error);
            yield break;
        }

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webRequest);

        if (bundle == null)
        {
            Debug.LogError("bundle is null");
            yield break;
        }

        var prefab = bundle.LoadAsset<GameObject>("BundleTest_1");
        Instantiate(prefab);
        bundle.Unload(true);

    }


}
