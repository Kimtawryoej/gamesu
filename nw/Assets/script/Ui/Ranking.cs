using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : Connection<Ranking>
{
    public Text[] score = new Text[4];
    public float[] countText = new float[4];
    float savescore;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }
    void Start()
    {
        Debug.Log(json.Instance == null);
        json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
        json.Instance.Save();
        Debug.Log(json.Instance.playerData.score[0]);
        for (int i = 0; i < countText.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (json.Instance.playerData.score[j] > json.Instance.playerData.score[j + 1])
                {
                    if (json.Instance.playerData.score[j+1] == 0)
                    {
                        break;
                    }
                    savescore = json.Instance.playerData.score[j];
                    json.Instance.playerData.score[j] = json.Instance.playerData.score[j + 1];
                    json.Instance.playerData.score[j + 1] = savescore;
                }
            }
        }

        score[0].text = $"{json.Instance.playerData.save[0]} : {json.Instance.playerData.score[0].ToString()}";
        score[1].text = $"{json.Instance.playerData.save[1]} : {json.Instance.playerData.score[1].ToString()}";
        score[2].text = $"{json.Instance.playerData.save[2]} : {json.Instance.playerData.score[2].ToString()}";
        score[3].text = $"{json.Instance.playerData.save[3]} : {json.Instance.playerData.score[3].ToString()}";
        Debug.Log(score[0]);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
