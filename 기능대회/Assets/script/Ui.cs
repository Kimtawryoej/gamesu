using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public static Ui Instance;
    public Slider Hp;
    public Slider Durability;
    public Slider skill;
    public Slider skill2;
    public Slider BossHp;
    public Slider Progres;
    public Text Score;
    public Text Coin;
    public Text skillparticel;
    public Text skillparticel2;
    int i = 0;
    int a = 0;
    //-----------------------------------------\
    public Image DIeUi;
    public Text score;
    public Button Ranking;
    public InputField Name;
    public void OnclickButton()
    {
        Debug.Log("·©Å·");
        PlayerPrefs.SetString("name", Name.text);
        ScoreManager.instance.findname(PlayerPrefs.GetString("name"));
        SceneManager.LoadScene("Ranking");
    }
    void Awake()
    {
        Ui instance = this;
        DIeUi.gameObject.SetActive(false);
        StartCoroutine(DieUi());
    }

    // Update is called once per frame
    void Update()
    {

        Progres.value = GameManager.instance.time / GameManager.instance.MaxTime;
        Hp.value = Player.Instance.hp / Player.Instance.maxHp;
        Durability.value = Player.Instance.HPMANAGER[1] / HpManager.Instance.MaxTime;
        BossHp.value = Boss.instance.hp / MonsterHpManager.instance.boss;
        skill.value = Skill.Instance.t3 / Skill.Instance.t;
        skill2.value = Skill.Instance.t5 / Skill.Instance.t2;
        Score.text = ":" + ScoreManager.instance.uiScore;
        Coin.text = ":" + GameManager.coin;
        skill1();
        skill22();
    }

    IEnumerator DieUi()
    {
        yield return new WaitUntil(() => !Player.Instance.gameObject.activeSelf);
        DIeUi.gameObject.SetActive(true);
        score.text = "Á¡¼ö" + ScoreManager.instance.uiScore;
    }

    IEnumerator skillParticel()
    {
        yield return new WaitForSeconds(1.5f);
        skillparticel.gameObject.SetActive(false);


    }
    IEnumerator skillParticel2()
    {
        yield return new WaitForSeconds(1.5f);
        skillparticel2.gameObject.SetActive(false);


    }

    void skill1()
    {
        if (i == 1 && Skill.Instance.t3 == Skill.Instance.t)
            i = 0;
        if (Skill.Instance.t3 != Skill.Instance.t && i == 0)
        {
            Debug.Log("www");
            i = 1;
            skillparticel.gameObject.SetActive(true);
            StartCoroutine(skillParticel());
        }
    }

    void skill22()
    {
        if (a == 1 && Skill.Instance.t5 == Skill.Instance.t2)
            a = 0;
        if (Skill.Instance.t5 != Skill.Instance.t2 && a == 0)
        {
            Debug.Log("www");
            a = 1;
            skillparticel2.gameObject.SetActive(true);
            StartCoroutine(skillParticel2());
        }
    }
}
