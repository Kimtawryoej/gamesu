using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using JetBrains.Annotations;
using System.Text;
using UnityEngine.UI;
using System.Linq;
using System;

[System.Serializable] // json은 직렬화를 해줘야 실행가능
public class PlayerData
{
    public Vector3 position;
    public float time2;
    public int score5;
    public float[] score = new float[4];
    public string[] save = new string[4];
}

public class json : Connection<json>
{
    //public int Age 
    //{
    //    get => PlayerPrefs.GetInt("Age"); 
    //    set => PlayerPrefs.SetInt("Age", value);
    //} // 간단하게 저장할떄 PlayerPrefs를 쓴다

    public PlayerData playerData = new PlayerData();
    public void Save()
    {
        playerData.position = Player.Instance.transform.position;
        playerData.time2 = Player.time;
        playerData.score5 = diamond.score;
        //playerData.score[0] = Ranking.Instance.countText[0];
        //playerData.score[1]= Ranking.Instance.countText[1];
        //playerData.score[2]= Ranking.Instance.countText[2];
        //playerData.score[3] = Ranking.Instance.countText[3];
        Debug.Log(Ranking.Instance.score.Length);
        for (int i = 0; i < Ranking.Instance.score.Length; i++)
        {
            if (playerData.score[i] == 0 && Ranking.Instance.gameObject.activeSelf == true)
            {
                playerData.score[i] = Player.time;
                playerData.save[i] = NameInput.Instance.input.text;
                break;
            }
        }

        if (playerData.score.Max() > Player.time && playerData.score[0] != 0 && playerData.score[1] != 0 && playerData.score[2] != 0 && playerData.score[3] != 0 && Ranking.Instance.gameObject.activeSelf == true)
        {
            Debug.Log("wwww");
            int a = Array.IndexOf(playerData.score, playerData.score.Max());
            playerData.score[a] = Player.time;
            playerData.save[a] = NameInput.Instance.input.text;
        }

        FileStream fs = new FileStream(Application.dataPath + "/test.json", FileMode.Create);
        string jsondata = JsonUtility.ToJson(playerData);
        byte[] data = Encoding.UTF8.GetBytes(jsondata);
        fs.Write(data, 0, data.Length);
        fs.Close();

    }

    public T LoadData<T>(string path)
    {
        string data = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(data);
    }
}
