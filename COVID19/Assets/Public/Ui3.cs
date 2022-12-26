using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Ui3 : MonoBehaviour
{
    public static Ui3 instance;
    public Text Text;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    float[] countText = new float[4];
   
    // Start is called before the first frame update
    void Start()
    {
        int Save = Public.Instance.datas.score[0];
        
        Public.Instance.datas = json.Instance.LoadData<Data>(Application.dataPath + "/test.json");
        Public.Instance.datas.score[0] = Save;

        countText[0] = Save;
        countText[1] = Public.Instance.datas.score[1];
        countText[2] = Public.Instance.datas.score[2];
        countText[3] = Public.Instance.datas.score[3];


        if (countText[0] != 0 && countText[1] != 0)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (countText[j] > countText[j + 1])
                    {
                        float a = countText[j];
                        float b = countText[j + 1];
                        countText[j] = b;
                        countText[j + 1] = a;
                    }
                }
            }
        instance = this;
        Text.text = countText[0].ToString();
        Text2.text = countText[1].ToString();
        Text3.text = countText[2].ToString();
        Text4.text = countText[3].ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

}

