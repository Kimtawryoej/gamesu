using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Bullet bullet  =new Bullet();
    float PAtteren = 0;
    public GameObject Bullet;
    void Start()
    {
        StartCoroutine(PatterenAttack());
        StartCoroutine(patterenChanage());
    }

    
    void Update()
    {
        transform.LookAt(Player.Instance.transform);
    }

    IEnumerator PatterenAttack()
    {
        while(true)
        {
            switch(PAtteren)
            {
                case 0:
                    bullet.Bulletshot(20,new Vector3(0,16,0),gameObject.transform,Bullet);
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 1:
                    yield return null;
                    break;
                case 2:
                    yield return null;
                    break;
                case 3:
                    yield return null;
                    break;
            }
        }
    }

    IEnumerator patterenChanage()
    {
        while(true)
        {
            yield return new WaitForSeconds(7);
            if (PAtteren == 3)
                PAtteren = -1;
            PAtteren += 1;
        }
    }
}
