using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpUi : MonoBehaviour
{
    public static BossHpUi instance;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

}
