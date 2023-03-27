using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    float hp;
    float skillcool = 10;
    float skillcool2 = 20;
    public GameObject Booms;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && skillcool == 10)
        {
            Hp();
            Debug.Log("실행");
            StartCoroutine(Cool());
        }
        if (Input.GetKey(KeyCode.G) && skillcool2 == 20)
        {
            Booms.SetActive(true);
            StartCoroutine(Cool2());
        }
    }
    IEnumerator Cool()
    {
        float savecool = skillcool;
        while (skillcool > 0)
        {
            skillcool -= Time.deltaTime;
            //Debug.Log(cool);
            yield return null;
        }
        skillcool = savecool;
    }
    IEnumerator Cool2()
    {
        float savecool = skillcool2;
        while (skillcool2 > 0)
        {
            skillcool2 -= Time.deltaTime;
            //Debug.Log(cool);
            yield return null;
        }
        skillcool2 = savecool;
    }
    void Hp()
    {
        hp = Mathf.Clamp(Player.instance.Hp = 150, 0, 150);
        Debug.Log("회복");
    }
}
