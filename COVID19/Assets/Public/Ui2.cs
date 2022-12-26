using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui2 : json
{
    Button button;
    bool rue = true;

   
    public void OnClickButton()
    {
        SceneManager.LoadScene("Stage1");
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
