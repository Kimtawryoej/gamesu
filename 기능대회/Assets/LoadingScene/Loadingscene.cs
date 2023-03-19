using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadingscene : Singleton<Loadingscene>
{
    public Slider loadingbar;
    static string sceneName;
    float time;
    public void Scene(string SceneName)
    {
        SceneManager.LoadScene("LoadScene");
        sceneName = SceneName;
    }

    private void Awake()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        Debug.Log(sceneName);
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        load.allowSceneActivation = false;
        while (!load.isDone)
        {
            time += Time.deltaTime;
            loadingbar.value = time / 6;
            yield return null;
            Debug.Log(load.progress);
            if (load.progress >= 0.9f && time >=6)
            {
                Debug.Log("로딩완료");
                load.allowSceneActivation = true;
            }
        }
        //yield return new WaitUntil(() => load.progress > 0.9f);
    }
}
