using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class savepoint : Connection<savepoint>
{
    public static int position = 0;
    public int save = 0;
   public static  int siv = 1;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        if(save != 0)
        {
            SceneManager.LoadScene("Main");
            siv = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


