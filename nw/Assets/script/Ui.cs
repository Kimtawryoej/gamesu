using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public static Ui Instance;
    public Text countText;
    public Text countText2;
    public Sprite[] ChangeHP = new Sprite[2];  
     public Image HP;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "move:" + Player.Instance.move;
        countText2.text = "jump:" + Player.Instance.jump;
        if(Player.Instance.hp == 2)
        {
            HP.sprite = ChangeHP[0];
        }
        else if(Player.Instance.hp == 1)
        {
            HP.sprite = ChangeHP[1];
        }
       
    }
}
