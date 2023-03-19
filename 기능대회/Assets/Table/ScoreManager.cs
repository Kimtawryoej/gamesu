using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Table table;
    int a;
    public int uiScore;
    public bool Bool = false;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        if (instance != null)
            DontDestroyOnLoad(gameObject);
    }


    public int findscore(int score)
    {
        for (int i = 0; i < 5; i++)
        {
            if (table.score[i] == 0 && !Bool)
            {
                a = i;
                Bool = true;
                Debug.Log("@@");
                table.score[i] += score;
                break;
            }
            else if (a == i && Bool)
            {
                table.score[i] += score;
                break;
            }

        }
        return table.score[a];
    }


    public void  findname(string name)
    {
        for (int i = 0; i < 5; i++)
        {
            if (table.Name[i] == "")
            {
                table.Name[i] = name;
                break;
            }
        }
    }
}
