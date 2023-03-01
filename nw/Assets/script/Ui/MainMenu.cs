using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Connection<MainMenu>
{
    public static int position = 0;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        SceneManager.LoadScene("Main");
        Player.time = 0;
        Player.hp = 3;
        SceneManager.LoadScene("MainScreen");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
