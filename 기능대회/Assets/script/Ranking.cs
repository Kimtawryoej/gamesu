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

public class Ranking : MonoBehaviour
{

    public List<Text> score = new List<Text>();
    string saveArray;
    int destory = 10;
    //Dictionary<string, int> scoreDict = new Dictionary<string, int>();
    List<KeyValuePair<string, int>> Dict = new List<KeyValuePair<string, int>>();
    Text text;

    void Start()
    {


        if (ScoreManager.instance.table.score[4] != 0)
        {
            if (ScoreManager.instance.table.score[Array.IndexOf(ScoreManager.instance.table.score, ScoreManager.instance.table.score.Min())] < ScoreManager.instance.table.score[4])
            {
                ScoreManager.instance.table.Name[Array.IndexOf(ScoreManager.instance.table.score, ScoreManager.instance.table.score.Min())] = ScoreManager.instance.table.Name[4];
                ScoreManager.instance.table.Name[4] = "";
                ScoreManager.instance.table.score[Array.IndexOf(ScoreManager.instance.table.score, ScoreManager.instance.table.score.Min())] = ScoreManager.instance.table.score[4];
                ScoreManager.instance.table.score[4] = 0;
            }
            else
            {
                ScoreManager.instance.table.Name[4] = "";
                ScoreManager.instance.table.score[4] = 0;
            }
        }







        for (int i = 0; i < 4; i++)
        {
            Dict.Add(new KeyValuePair<string, int>(ScoreManager.instance.table.Name[i], ScoreManager.instance.table.score[i]));
        }
        var sortedWords =
       from w in Dict
       orderby w.Value descending
       select w.Value;
        int[] numsArray = sortedWords.ToArray();
        string[] save = new string[4];

        for (int i = 0; i < 4; i++)
        {
            var key = Dict.Where(x => x.Value == numsArray[i]).Select(x => x.Key);
            //save[i] = key.ToString();
            //Debug.Log(string.Join(",", key));
            score[i].text = string.Join(",", key) + ":" + numsArray[i];
        }



        for (int i = 0; i < score.Count; i++)
        {
            for (int a = 0; a < score.Count; a++)
            {
                if (score[i].text == score[a].text && destory == 10)
                {
                    if (a != i)
                    {
                        Debug.Log(i +":"+ a);
                        Destroy(score[i]);
                        destory = i;
                        break;
                    }
                }
            }
        }
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        yield return new WaitUntil(() => (destory != 10));
        for (int i = destory + 1; i < 4; i++)
        {
            score[i].gameObject.transform.position += new Vector3(0, 149, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
