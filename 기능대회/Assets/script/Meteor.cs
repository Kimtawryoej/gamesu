using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public static Meteor Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stop());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -0.5f *Time.time* Time.fixedDeltaTime, 0);
        if ((TriggerManager.instance.MonsterHp[GameObject.FindWithTag("meteor")] <= 0))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
