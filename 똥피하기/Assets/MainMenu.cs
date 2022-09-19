using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //HideInInspector = Public 변수를 인스펙터창에 안 보이게 하는 어트리뷰트
    [HideInInspector] public string sceneName = "SampleScene";

    [SerializeField] private int a;//외울려고 적어둔것

    public void OneClickNewGame()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(sceneName);
        Debug.Log("시작");
    }

    public void OnClickLoad()
    {
        Debug.Log("계속하기");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }




}



