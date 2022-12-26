using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.IO.Pipes;
using Newtonsoft.Json;
using UnityEditor.Tilemaps;
using Unity.VisualScripting;

public class json : MonoSingleton<json>
{
    
    // Start is called before the first frame update
    void Start()
    {
       
        //File.WriteAllText(Application.dataPath + "/test.json", jsondata);

    }
    public void Save()
    {

        FileStream fs = new FileStream(Application.dataPath + "/test.json", FileMode.Create);
        string jsondata = JsonUtility.ToJson(Public.Instance.datas);
        byte[] data = Encoding.UTF8.GetBytes(jsondata) ; // 외부 에서 받은 유니코드나 utf-8방식의 문자열을 인코딩-디코딩 거치지 않고 출력하면 출력이 제대로 되지 않아 해당 문자열을 디코딩 하는 과정이다
        fs.Write(data, 0, data.Length);
        fs.Close();
        Debug.Log(data);
    }


    public T LoadData<T>(string path)
    {
        string data = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(data);
    }

    private void OnEnable()
    {
        
    }


}
