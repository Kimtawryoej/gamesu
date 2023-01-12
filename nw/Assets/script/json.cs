using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using JetBrains.Annotations;
using System.Text;

[System.Serializable] // json은 직렬화를 해줘야 실행가능
public class PlayerData
{
    public Vector3 position;
    public int Move;
    public int Jump;
    public int JumpPower;
    public int JumpPower2;
    public int Speed2;
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
        playerData.Move = Player.Instance.move;
        playerData.Jump = Player.Instance.jump;
        playerData.JumpPower = Player.Instance.jumpPower;
        playerData.JumpPower2 = Player.Instance.jumpPower2;
        playerData.Speed2 = Player.Instance.speed2;



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
