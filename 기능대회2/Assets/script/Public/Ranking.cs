using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Ranking : MonoBehaviour
{
    public Table table;
    public List<Text> scoreandNAme = new List<Text>();
    Dictionary<string, float> ranking = new Dictionary<string, float>();
    Dictionary<string, float> lastranking = new Dictionary<string, float>();
    List<float> c = new List<float>();
    List<string> d = new List<string>();
    bool Bool = false;
    bool Bool2 = true;
    public List<float> score = new List<float>();
    public List<string> lastLanking = new List<string>();
    int chance = 0;
    int i = 0;
    private void Start()
    {
        if (table.saveName.Count == 0)
        {
            table.saveName.Add(table.Name);
            table.saveScore.Add(table.scroe);
        }
        else if (table.saveName.Count > 0)
        {
            foreach (var a in table.saveName)
            {
                if (table.Name == a)
                {
                    Bool2 = false;
                    break;
                }
            }
            if (Bool2)
            {
                table.saveName.Add(table.Name);
                table.saveScore.Add(table.scroe);
                Debug.Log("WW");
            }

        }
    }
    void Update()
    {
        if (!Bool && Bool2)
        {
            
            Bool = true;
            for (int i = 0; i < table.saveName.Count; i++)
            {
                ranking.Add(table.saveName[i], table.saveScore[i]);
            }
            var a = from w in table.saveScore orderby w descending select w;
            c = a.ToList();
            var same = c.GroupBy(x => x).Where(g => g.Count() > 1 ).Select(g => g.Key);
            foreach (var item in same)
            {

                score.Add(item);
            }
            var different = c.GroupBy(x => x).Where(g => g.Count() <= 1).Select(g => g.Key);
            foreach (var item in different)
            {
                score.Add(item);
            }
            var SCORE = from w in score orderby w descending select w;
            foreach (var item in SCORE)
            {
                Debug.Log(item);
            }
            foreach (var item in ranking)
            {
              
                if (!lastranking.ContainsValue(item.Value))
                {
                    lastranking.Add(item.Key, item.Value);
                }
            }
            
            foreach (var item in SCORE)
            {
                foreach (var item2 in lastranking)
                {
                    if (item == item2.Value)
                        lastLanking.Add(item2.Key);
                }
            }
            //for (int i = 0; i < score.Count; i++)
            //{
            //    var b = lastranking.Where(x => x.Value == SCORE.ToList()[i]).Select(x => x.Key);
            //    lastLanking = b.ToList();
            //}
            foreach (var item in lastLanking)
            {
                
                if (i < 4)
                    scoreandNAme[i].text = item + ":" + SCORE.ToList()[i];
                i += 1;
            }
            

        }
        //딕셔너리에 값넣고 린큐로 벨류값 정렬해서 값 받고 
    }
}
