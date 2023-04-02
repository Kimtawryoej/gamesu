using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Skill : SingleTone<Skill>
{
    Dictionary<KeyCode, Action> SKILL = new Dictionary<KeyCode, Action>();
    float FSkillCount = 5;
    public float time;
    float MaxTime;
    float GSkillCount = 5;
    public float time2;
    ParticleAni particle = new ParticleAni();
    [SerializeField]
    GameObject BigBoom;
    float MaxTime2;
    [SerializeField]
    GameObject BoomObject;
    float FSkillCool
    {
        get => FSkillCount;
        set
        {
            MaxTime = value;
            time = value;
            StartCoroutine(FSKILL());
        }
    }
    float GSkillCool
    {
        get => FSkillCount;
        set
        {
            MaxTime2 = value;
            time2 = value;
            StartCoroutine(FSKILL2());
        }
    }
    void Start()
    {
        Action F = () =>
        {
            if (time == 0 && FSkillCount > 0)
            {
                Player.Instance.Hp = 150;
                Debug.Log("¹ßµ¿");
                FSkillCool = 10;
            }
        };
        Action G = () =>
        {
            if (time2 == 0 && GSkillCount > 0)
            {
                Debug.Log("ÆøÅº¹ßµ¿");
                StartCoroutine(BoomObject.GetComponent<Animation>().AniPlay("Move", 2));
                StartCoroutine(turm());
                GSkillCool = 15;
            }
        };
        SKILL = new Dictionary<KeyCode, Action>
        {
            {KeyCode.F,F},
            {KeyCode.G,G}
        };
    }


    void Update()
    {
        if (Input.anyKey)
        {
            foreach (var a in SKILL)
            {
                if (Input.GetKey(a.Key))
                {
                    a.Value();
                }
            }
        }
    }
    IEnumerator FSKILL()
    {
        for (float i = MaxTime; i >= 0; i -= Time.deltaTime)
        {
            time = Mathf.Clamp(time -= Time.deltaTime, 0, MaxTime);
            yield return null;

        }
        FSkillCount -= 1;
    }
    IEnumerator FSKILL2()
    {
        for (float i = MaxTime2; i >= 0; i -= Time.deltaTime)
        {
            time2 = Mathf.Clamp(time2 -= Time.deltaTime, 0, MaxTime2);
            yield return null;

        }
        GSkillCount -= 1;
    }
    IEnumerator turm()
    {
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(particle.Charging(2.8f, new Vector3(-1016.8f, 135.2f, -0.5f), BigBoom,90));
        AllMonster[] FindMonster = FindObjectsOfType<AllMonster>();
        foreach (var a in FindMonster)
        {
            a.GetComponent<Unit>().Attack = -3;
            a.GetComponent<Unit>().HpManager(a.gameObject.GetComponent<Unit>().Hp);
            a.GetComponent<Unit>().Attack = -1;
        }
    }
}
