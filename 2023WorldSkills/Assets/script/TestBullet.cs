using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public UnitType targetType;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit) && unit.type == targetType)
            unit.ChangeHp(-damage);
    }
}
