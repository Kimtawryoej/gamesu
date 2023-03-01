using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : Connection<HpManager>
{
    public enum State { NULL, PlayerState, MonsterState, MidBossState, BossState }
    public float PlayerHp = 10000;
    public float[] LvPlayerHp = new float[4] { 3, 0, 0, 0 };
    public float MonsterHp = 3;
    [SerializeField]
    public static float MidMonsterHp = 20;
    public State state = State.NULL;

    private void Update()
    {
        if (PlayerHp <= 0)
        {
            Player.Instance.gameObject.SetActive(false);
        }
        if (Monster.Hp <= 0 && state == State.MonsterState)
        {
            ObjectPool.Instance.RETURN(Monster.Instance.gameObject);
            ExperienceManager.Instance.Experience += 10;
            state = State.NULL;
        }
        if (Midboss.Instance.Hp <= 0 && state == State.MidBossState)
        {
            Midboss.Instance.gameObject.SetActive(false);
            ExperienceManager.Instance.Experience += 70;
            Midboss.Instance.sinho = false;
            GameManager.Instance.StartCoroutine(GameManager.Instance.Summons());
            state = State.NULL;
        }
        if (Boss.Instance.Hp <= 0 && state == State.BossState)
        {
            Boss.Instance.gameObject.SetActive(false);
            ExperienceManager.Instance.Experience += 130;
            Midboss.Instance.sinho = false;
            GameManager.Instance.StartCoroutine(GameManager.Instance.Summons());
            state = State.NULL;
        }

    }
}
