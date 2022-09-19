using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamedirector : MonoBehaviour
{
    GameObject Hpgage;
    // Start is called before the first frame update
    void Start()
    {
        this.Hpgage = GameObject.Find("Hpgage");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void DecreaseHp()
    {
        this.Hpgage.GetComponent<Image>().fillAmount -= 0.2f;
    }
    public void GameOver()
    {
        if(this.Hpgage.GetComponent<Image>().fillAmount==0)
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
