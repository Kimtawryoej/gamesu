using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUi : MonoBehaviour
{
    public Text Score;
    public Slider MaxScore;
    public InputField Name;
    public Button Ranking;
    public Button NextStage;
    GameObject buttoName;
    float SCORE;
    Scrpt Player = new Scrpt();
    void Start()
    {
        GameManager.Instance.table.Score *= 0.1f * GameManager.Instance.table.Time;
        Score.text = "'" + GameManager.Instance.table.Score + "'";
        if (Scrpt.DicCheck)
            NextStage.gameObject.SetActive(false);
        if (!Scrpt.DicCheck)
        {
            Ranking.gameObject.SetActive(false);
            Name.gameObject.SetActive(false);
        }
        StartCoroutine(MAXSCROE());
    }

    private void Update()
    {
        GameManager.Instance.table.Name = Name.text;
    }


    public void ClickButton()
    {
        buttoName = EventSystem.current.currentSelectedGameObject;
        if (buttoName.name == "Ranking")
            SceneManager.LoadScene("Ranking");
        else if (buttoName.name == "NextStage")
            SceneManager.LoadScene("Sage2");
    }

    IEnumerator MAXSCROE()
    {
        while (SCORE < GameManager.Instance.table.Score)
        {
            SCORE += Time.deltaTime * 1000;
            MaxScore.value = SCORE / 99999;
            yield return null;
        }
    }
}
