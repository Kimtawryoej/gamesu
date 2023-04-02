using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider Hp;
    public Slider fuel;
    public Text time;
    public Text score;
    public Slider skill;
    public Slider skill2;
    public Text DontTry;
    public Animator ai;
    public Slider BossHp;
    public Text[] ITEMs = new Text[3];
    public List<GameObject> items;
    public Slider progress;
    public GameObject Boss;
    AllMonster all = new AllMonster();


    // Start is called before the first frame update
    void Awake()
    {
        DontTry.gameObject.SetActive(false);
        BossHp.gameObject.SetActive(false);
    }
    private void Start()
    {
        foreach (var item in ITEMs)
        {
            item.gameObject.SetActive(false);
        }
        StartCoroutine(bos());
    }
    public void ButtonCLick()
    {
        SceneManager.LoadScene("Ranking");
    }
    // Update is called once per frame
    void Update()
    {
        progress.value = Time.time / 60;
        Hp.value = Scrpt.Instance.Hp / 150;
        fuel.value = Scrpt.Instance.Fuel / 60;
        time.text = "Time:" + Time.time;
        GameManager.Instance.table.Time = Time.time;
        score.text = "Score:" + GameManager.Instance.table.Score;
        skill.value = Skill.Instance.CoolTime1 / 10;
        skill2.value = Skill.Instance.CoolTime2 / 10;
        if (Bos.Instance.gameObject.activeSelf)
        {
            BossHp.gameObject.SetActive(true);
            if (Boss.gameObject.GetComponent<AllMonster>())
            {
                BossHp.value = Boss.gameObject.GetComponent<AllMonster>().Hp / 70;
            }

        }
        else if (!Bos.Instance.gameObject.activeSelf)
            BossHp.gameObject.SetActive(false);
        if (Input.GetKey(KeyCode.F) && Skill.Instance.CoolTime1! < 9)
        {
            DontTry.gameObject.SetActive(true);
            StartCoroutine(ds());
        }
        else if (Input.GetKey(KeyCode.G) && Skill.Instance.CoolTime2 < 9)
        {
            DontTry.gameObject.SetActive(true);
            StartCoroutine(ds());
        }
        if (ITEM.Instance.Saveitems.Count > 0)
        {
            for (int i = 0; i < ITEM.Instance.Saveitems.Count; i++)
            {
                ITEMs[i].gameObject.SetActive(true);
                ITEMs[i].text = ITEM.Instance.Saveitems[i];
            }
            if (GameManager.Instance.ITEMS.Count >= 3)
            {
                ITEMs[3].gameObject.SetActive(true);
            }
            StartCoroutine(des());
            ITEM.Instance.Saveitems.Clear();
            GameManager.Instance.ITEMS.Clear();
        }
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(2);
        foreach (var item in ITEMs)
        {
            item.gameObject.SetActive(false);
        }
    }
    IEnumerator ds()
    {
        yield return new WaitUntil(() => ai.GetCurrentAnimatorStateInfo(0).IsName("MOVE") && ai.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f);
        yield return new WaitForSeconds(1.5f);
        DontTry.gameObject.SetActive(false);
    }
    IEnumerator bos()
    {
        yield return new WaitUntil(() => Time.time >= 60);
        Bos.Instance.gameObject.SetActive(true);

    }
}
