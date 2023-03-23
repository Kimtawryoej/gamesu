using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadingscene : Singleton<Loadingscene>
{
    public Slider loadingbar;
    public static string sceneName;
    public float time;
    public AsyncOperation load;
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
        load = SceneManager.LoadSceneAsync(sceneName);
        load.allowSceneActivation = false;
        if(sceneName == "Stage2")
            instatie.Instance.StopAllCoroutines();
        while (!load.isDone)
        {
            time += Time.deltaTime;
            loadingbar.value = time / 6;
            yield return null;
            if (load.progress >= 0.9f && time >= 6)
            {
                load.allowSceneActivation = true;
                if (sceneName == "Stage2")
                {
                    instatie.Instance.StartCoroutine(instatie.Instance.Insta());
                    instatie.Instance.StartCoroutine(instatie.Instance.Insta2());
                }
            }
        }
        //yield return new WaitUntil(() => load.progress > 0.9f);
    }
}
