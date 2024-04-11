using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Player,
    Enemy
}
public class Unit : Singleton<Unit>
{
    
    [field: SerializeField] public UnitType type { get; protected set; }

    public float hp;
    public float maxHp;
    public static  int a;

    public void ChangeHp(float value)
    {
        hp = Mathf.Clamp(hp + value, 0, maxHp);
        Bossskill4.damage = 1;
        if (hp == 0)
        {
            OnDie(TriggerManager.instance.monsterdata);
            Random(TriggerManager.instance.monsterdata);
        }
    }

    public virtual void OnDie(Collider2D collision) { Debug.Log("¿À·ù"); }
    void Random(Collider2D collision)
    {
        a = UnityEngine.Random.Range(0, 5);
        Debug.Log(a);
        Instantiate(ItemManager.Instance.Key[a], collision.transform.position, Quaternion.identity);
    }
}
