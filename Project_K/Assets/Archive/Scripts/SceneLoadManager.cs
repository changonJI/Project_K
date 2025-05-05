using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    public static string str_TargetScene;
    [SerializeField] private Image pg_Loading;

    /// <summary>
    /// 로딩씬에서 다음씬으로 넘어가도록 TargetSceneName을 저장한다.
    /// </summary>
    /// <param name="sceneName">Target Scene Name</param>
    public static void LoadScene(string sceneName)
    {
        str_TargetScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    /// <summary>
    /// LoadingScene이 Load되면 Start함수 호출하여 다음씬으로 넘김
    /// </summary>
    private void Start()
    {
        StartCoroutine(LoadScene());
    }


    /// <summary>
    /// 타겟 로드
    /// </summary>
    IEnumerator LoadScene()
    {
        yield return null;

        //AsyncOperation.allowSceneActivation : 데이터를 모두 받은 상태일때 씬 화면을 활성화 할 것인지 여부
        //AsyncOperation.isDone : 준비 되었는지 여부
        //AsyncOperation.progress : 작업의 진행 정도를 0과 1 사이값으로 확인
        AsyncOperation op = SceneManager.LoadSceneAsync(str_TargetScene);

        op.allowSceneActivation = false;
        pg_Loading.fillAmount = 0;

        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                pg_Loading.fillAmount = Mathf.Lerp(pg_Loading.fillAmount, op.progress, timer);
                if (pg_Loading.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                pg_Loading.fillAmount = Mathf.Lerp(pg_Loading.fillAmount, 1f, timer);
                if (pg_Loading.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
