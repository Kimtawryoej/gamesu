using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : SingleTone<Ui>
{
    public Image jum;
    public Camera camer;
    public Text Score;
    public Text time;
    public Slider hp;
    public Slider FUel;
    public Slider progress;
    bool Bool = true;
    public Slider BossHp;
    public List<Text> ITEM = new List<Text>();
    //죽을때ui
    public Image DieUi;
    public InputField Name;
    public Button SceneLoad;
    //다음스테이지Ui
    public Image NextStage;
    public Button NextStageButton;
    float tim;
    public void ClickButton()
    {
        SceneManager.LoadScene("Ranking");
    }
    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Stage2");
        NextStage.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        tim = 0;
        DieUi.gameObject.SetActive(false);
        NextStage.gameObject.SetActive(false);
        StartCoroutine(die());
        StartCoroutine(Next());
    }

    // Update is called once per frame
    void Update()
    {
        tim += Time.deltaTime;
        if (DieUi.gameObject.activeSelf)
            TriggerManager.Instance.table.Name = Name.text;

        if (tim<= 60)
        { progress.value = tim / 60; BossHp.gameObject.SetActive(false); }
        else if (tim > 60)
        { BossHp.gameObject.SetActive(true); BossHp.value = Boss.instance.Hp / 50; }
        TriggerManager.Instance.table.Time = Time.time;
        if (GameManager.Instance.find != null)
        {
            jum.transform.position = camer.WorldToScreenPoint(GameManager.Instance.find.transform.position);
        }

        hp.value = Player.instance.Hp / 150;
        FUel.value = Player.instance.Fuel / 60;
        if (GameManager.Instance.find == null)
            jum.transform.position = camer.WorldToScreenPoint(Player.instance.transform.position + new Vector3(0, 2, 0));
        Score.text = "Score:" + TriggerManager.Instance.table.scroe;
        time.text = "Time:" + TriggerManager.Instance.table.Time;
        if (ITEM != null && Bool)
        {
            for (int i = 0; i < ITEM.Count; i++)
            {
                Debug.Log("발동");
                ITEM[i].gameObject.SetActive(true);
                ITEM[i].text = ItemManager.Instance.ITEM[i] + "발동";
                StartCoroutine(des());
                if (i == ITEM.Count - 1)
                    StartCoroutine(re());
            }
        }
    }

    IEnumerator die()
    {
        yield return null;
        yield return new WaitUntil(() => !Player.instance.gameObject.activeSelf);
        DieUi.gameObject.SetActive(true);

    }
    IEnumerator Next()
    {
        yield return null;
        yield return new WaitUntil(() => !Boss.instance.gameObject.activeSelf && Boss.instance.Hp == 0);
        NextStage.gameObject.SetActive(true);


    }
    IEnumerator re()
    {
        Bool = false;
        yield return new WaitForSeconds(1.3f);
        ITEM.Clear();
        Bool = true;
    }


    IEnumerator des()
    {
        yield return new WaitForSeconds(1f);
        foreach (var item in ITEM)
            item.gameObject.SetActive(false);
    }
}
