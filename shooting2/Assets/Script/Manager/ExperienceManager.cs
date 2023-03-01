using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExperienceManager :Connection<ExperienceManager>
{
    public int Lv = 0;
    public float Experience = 0;
    bool execution = true;

    // Update is called once per frame
    void Update()
    {
        switch (Lv)
        {
            case 2:
                if (execution)
                {
                    execution = false;
                    HpManager.Instance.PlayerHp += HpManager.Instance.PlayerHp * 20 / 100;
                    HpManager.Instance.LvPlayerHp[1] = HpManager.Instance.PlayerHp;
                    //HpManager.Instance.MonsterHp += HpManager.Instance.MonsterHp * 20 / 100;
                    BulletManager.Instance.speed = BulletManager.Instance.speed * 80 / 100;
                    BulletManager.Instance.bullePower[0] += BulletManager.Instance.bullePower[0] * 20 / 100;
                    BulletManager.Instance.bullePower[1] += BulletManager.Instance.bullePower[1] * 20 / 100;
                }
                break;
            case 3:
                if (!execution)
                {
                    execution = true;
                    HpManager.Instance.PlayerHp += HpManager.Instance.PlayerHp * 20 / 100;
                    HpManager.Instance.LvPlayerHp[2] = HpManager.Instance.PlayerHp;
                    //HpManager.Instance.MonsterHp += HpManager.Instance.MonsterHp * 20 / 100;
                    BulletManager.Instance.speed = BulletManager.Instance.speed * 80 / 100;
                    BulletManager.Instance.bullePower[0] += BulletManager.Instance.bullePower[0] * 20 / 100;
                    BulletManager.Instance.bullePower[1] += BulletManager.Instance.bullePower[1] * 20 / 100;
                }
                break;
            case 4:
                if (execution)
                {
                    execution = false;
                    HpManager.Instance.PlayerHp += HpManager.Instance.PlayerHp * 20 / 100;
                    HpManager.Instance.LvPlayerHp[3] = HpManager.Instance.PlayerHp;
                    //HpManager.Instance.MonsterHp += HpManager.Instance.MonsterHp * 20 / 100;
                    BulletManager.Instance.speed = BulletManager.Instance.speed * 80 / 100;
                    BulletManager.Instance.bullePower[0] += BulletManager.Instance.bullePower[0] * 20 / 100;
                    BulletManager.Instance.bullePower[1] += BulletManager.Instance.bullePower[1] * 20 / 100;
                }
                break;
        }

        switch (Experience)
        {
            case 40:
                if (execution)
                {
                    Lv++;
                    execution = false;
                    HpManager.Instance.PlayerHp = HpManager.Instance.LvPlayerHp[0];
                }
                break;
            case 100:
                if (!execution)
                {
                    Lv++;
                    execution = true;
                    HpManager.Instance.PlayerHp = HpManager.Instance.LvPlayerHp[1];
                }
                break;
            case 200:
                if (execution)
                {
                    Lv++;
                    execution = false;
                    HpManager.Instance.PlayerHp = HpManager.Instance.LvPlayerHp[2];
                }
                break;
        }
    }
}
