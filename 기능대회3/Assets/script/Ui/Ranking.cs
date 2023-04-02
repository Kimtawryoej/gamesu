using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.Xml.Linq;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    Ranking2 ran;
    public static Ranking Instance { get; private set; }
    public Table table;
    public List<Text> text = new List<Text>();

    private void Awake()
    {
        Instance = this;
    }
    public void MainUi()
    {
        SceneManager.LoadScene("Main");
    }
    void Start()
    {
        if (table.Score != 0 && table.Name != "")
        {
            table.SaveScore.Add(table.Score);
            table.SaveName.Add(table.Name);
        }
        ran = new Ranking2(table.SaveScore, table.SaveName);
        List<KeyValuePair<string, float>> list = new List<KeyValuePair<string, float>>();
        foreach (var a in ran.ScoreDict)
        {
            list.Add(a);
        }

        var lis = from w in list orderby w.Value descending select w;
        List<KeyValuePair<string, float>> list2 = lis.ToList();
        for (int i = 0; i < list2.Count; i++)
        {
            text[i].text = list2[i].Key + ":" + list2[i].Value;
        }
    }
}
public class Ranking2
{
    public List<float> Score;
    public List<string> Name;
    public Dictionary<string, float> ScoreDict = new Dictionary<string, float>();
    public Ranking2(List<float> score, List<string> name)
    {
        Score = score;
        Name = name;
        for (int i = 0; i < Score.Count; i++)
        {
            ScoreDict.Add(Name[i], Score[i]);
        }
    }
}
