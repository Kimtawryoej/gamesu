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
    public Text TimeText;
    public Text Score;
    public Sprite[] ChangeHP = new Sprite[3];  
     public Image HP;
    [SerializeField]
    private Slider TeleportingSlider;
    [SerializeField]
    private Slider GageSlider;
    private float maxTim = 5;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        TeleportingSlider.value =  Teleportation.time / maxTim;
        GageSlider.value = GageMonster.Instance.time / maxTim;
    }

    // Update is called once per frame
    void Update()
    {
        
        TeleportingSlider.value = Teleportation.time / maxTim;
        GageSlider.value = GageMonster.Instance.time / maxTim;
        countText.text = "move:" + Player.Instance.move;
        countText2.text = "jump:" + Player.Instance.jump;
        TimeText.text = "시간:" + Player.time;
        Score.text = "점수:" + diamond.score;
        if(Player.hp == 2)
        {
            HP.sprite = ChangeHP[0];
        }
        else if(Player.hp == 1)
        {
            HP.sprite = ChangeHP[1];
        }
        else if (Player.hp == 3)
        {
            HP.sprite = ChangeHP[2];
        }

    }
}
