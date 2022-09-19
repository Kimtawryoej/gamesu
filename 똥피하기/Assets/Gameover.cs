using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum SceneIndex     //build 
{
    Main = 0,   //기본적으로 이 숫자들은 floot형
    Game = 1
}

public class Gameover : MonoBehaviour
{
    SceneIndex nowScene;
    public void OneClickNewGame()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene((int)SceneIndex.Game);
        Debug.Log("시작");
    }
}
