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
        byte[] data = Encoding.UTF8.GetBytes(jsondata) ; // �ܺ� ���� ���� �����ڵ峪 utf-8����� ���ڿ��� ���ڵ�-���ڵ� ��ġ�� �ʰ� ����ϸ� ����� ����� ���� �ʾ� �ش� ���ڿ��� ���ڵ� �ϴ� �����̴�
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
