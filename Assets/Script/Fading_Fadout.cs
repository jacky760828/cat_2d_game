using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading_Fadout:MonoBehaviour
{
    public static Fading_Fadout instance;

    public CanvasGroup fadeGroup;   // 淡入淡出
    public GameObject loadingUI;    // Loading Panel

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   // 永久存在
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartLoading(string sceneName)
    {
        StartCoroutine(Loading(sceneName));
    }

    private IEnumerator Loading(string sceneName)
    {
        loadingUI.SetActive(true);

        // 淡入
        yield return Fadesystem.FadeIn(fadeGroup,1f);

        // 載入場景
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 淡出
        yield return Fadesystem.FadeOut(fadeGroup,1f);

        loadingUI.SetActive(false);
    }

}
