using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui4 : json
{
    Button button;

    public void OnClickButton()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Public.Instance.datas.score[i] == 0)
            {
                Public.Instance.datas.score[i] = Public.Instance.datas.score[0];
                break;
            }
        }
        Public.Instance.datas.score[0] = 0;
        Save();
        SceneManager.LoadScene("Main");


    }
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
        //player = Player.Instance;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
