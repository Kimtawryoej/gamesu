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
    public int score;
    public string Name;
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


    public int findscore(int scores)
    {
        score += scores;
        return score;
    }


    public void findname(string name)
    {
        for (int i = 0; i < 5; i++)
        {
            if (Name == "")
            {
                Name = name;
                break;
            }
        }
    }
}
