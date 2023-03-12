using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Slider Hp;
    public Slider Durability;
    public Slider skill;
    public Slider skill2;
    public Slider BossHp;
    public Text Score;
    public Text Coin;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Hp.value = Player.Instance.HPMANAGER[0] / Player.Instance.MaxHp;
        Durability.value = Player.Instance.HPMANAGER[1] / HpManager.Instance.MaxTime;
        BossHp.value = TriggerManager.instance.MonsterHp[GameObject.FindWithTag("boss")] / MonsterHpManager.instance.boss;
        skill.value = Skill.Instance.t3 / Skill.Instance.t;
        skill2.value = Skill.Instance.t5 / Skill.Instance.t2;
        Score.text = ":"+GameManager.score;
        Coin.text = ":" + GameManager.coin;
    }
}
