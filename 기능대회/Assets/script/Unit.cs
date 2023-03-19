using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Player,
    Enemy
}

public class Unit : MonoBehaviour
{
    [field: SerializeField] public UnitType type { get; protected set; }

    public float hp;
    public float maxHp;


    public void ChangeHp(float value)
    {
        hp = Mathf.Clamp(hp + value, 0, maxHp);
        Debug.Log(hp);
        if (hp == 0)
        {
            OnDie(TriggerManager.instance.monsterdata);
            Random(TriggerManager.instance.monsterdata);
        }
    }

    public virtual void OnDie(Collider2D collision) { Debug.Log("¿À·ù"); }
    void Random(Collider2D collision)
    {
       int a = UnityEngine.Random.Range(0, 5);
        Instantiate(ItemManager.Instance.Key[a], collision.transform.position, Quaternion.identity);
    }
}
