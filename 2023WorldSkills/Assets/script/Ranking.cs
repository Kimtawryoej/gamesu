using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using static UnityEditor.Progress;
using System;
using Newtonsoft.Json.Linq;

public class Ranking : Singleton<Ranking>
{

    public DataSave Data = new DataSave();
    private Json json = new Json();
    [SerializeField] private InputField nickName;
    [SerializeField] private Button nameCheck;
    [SerializeField] private Button toHome;
    [SerializeField] List<Text> rank = new List<Text>();
    private void Start()
    {
        //if (ScoreManager.Score.Equals(0)) { nameCheck.gameObject.SetActive(false); nickName.gameObject.SetActive(false); }
        LoadRanking();
        //nameCheck.onClick.AddListener(() => { AddScore(nickName.text); LoadRanking(); nameCheck.gameObject.SetActive(false); nickName.gameObject.SetActive(false); });
        AddScore(ScoreManager.instance.Name); LoadRanking(); /*nameCheck.gameObject.SetActive(false); nickName.gameObject.SetActive(false);*/
        toHome.onClick.AddListener(() => SceneManager.LoadScene(1));
    }

    private void AddScore(string name)
    {
        Data.Datas.Add(new Data<string, float>(name, ScoreManager.instance.score));
        Debug.Log(ScoreManager.instance.score);
        json.ReadJson();
    }
    private void LoadRanking()
    {
        json.LoadJson();
        var loadScore = Data.Datas.OrderByDescending(x => x.Score).Select(x => x).ToList();
        for (int i = 0; i < loadScore.Count; i++)
        {
            rank[i].text = $"{i + 1}. {loadScore[i].Name}:{loadScore[i].Score}";
        }
    }
}
