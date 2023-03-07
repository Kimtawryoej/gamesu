using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score;
    public bool Bool = true;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (score == 100)
        {
            Boss.instance.gameObject.SetActive(true);
           Bool = true;
        }
        if (Boss.instance.gameObject.activeSelf)
            BossHpUi.instance.gameObject.SetActive(true);
        foreach (var key in TriggerManager.instance.MonsterHp)
        {
            if (key.Value <= 0 && Bool)
            {
                score += 20;
                Bool = false;

                Debug.Log("Á¡¼ö");
                break;
            }
        }

    }
}
