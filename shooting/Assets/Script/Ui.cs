using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Slider bar;
    public Slider Fcool;
    public Slider SpaceCool;
    float coolmax = 3;
    float[] maxscore =new float[3] {40,100,200};
    public Text leavel;
    public Text Hp2;

    // Start is called before the first frame update
    void Start()
    {
        bar.value = Player.Instance.score / maxscore[0];
        Fcool.value = Player.Instance.changeTime / coolmax;
    }

    // Update is called once per frame
    void Update()
    {
        //경험치 표시
        if (Player.Instance.lv <= 1)
        {
            bar.value = Player.Instance.score / maxscore[0];
        }
        else if (1 < Player.Instance.lv && Player.Instance.lv <= 2)
        {
            bar.value = Player.Instance.score / maxscore[1];
        }
        else if (2 < Player.Instance.lv && Player.Instance.lv <= 3)
        {
            bar.value = Player.Instance.score / maxscore[2];
        }
        leavel.text = "Lv:" + Player.Instance.lv;
        Hp2.text = "HP:" + Hp.Instance.PlayerHp;
        
        Fcool.value = Player.Instance.changeTime / coolmax;
        SpaceCool.value = Player.Instance.time / coolmax;
    }
}
