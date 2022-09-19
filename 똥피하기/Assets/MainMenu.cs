using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //HideInInspector = Public ������ �ν�����â�� �� ���̰� �ϴ� ��Ʈ����Ʈ
    [HideInInspector] public string sceneName = "SampleScene";

    [SerializeField] private int a;//�ܿ���� ����а�

    public void OneClickNewGame()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(sceneName);
        Debug.Log("����");
    }

    public void OnClickLoad()
    {
        Debug.Log("����ϱ�");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }




}



