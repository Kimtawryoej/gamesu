using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    string name;
    int[] score = new int[4];

    // Update is called once per frame
    void Update()
    {

        if (score[0] == 0)
        {
            score[0] = PlayerPrefs.GetInt("score", GameManager.instance.score);
            PlayerPrefs.SetInt("SCORE0", score[0]);
        }
        if (score[1] == 0)
        {
            score[1] = PlayerPrefs.GetInt("score", GameManager.instance.score);
            PlayerPrefs.SetInt("SCORE1", score[1]);
        }
        if (score[2] == 0)
        {
            score[2] = PlayerPrefs.GetInt("score", GameManager.instance.score);
            PlayerPrefs.SetInt("SCORE2", score[2]);
        }
        if (score[3] == 0)
        {
            score[3] = PlayerPrefs.GetInt("score", GameManager.instance.score);
            PlayerPrefs.SetInt("SCORE3", score[3]);
        }
    }
}
