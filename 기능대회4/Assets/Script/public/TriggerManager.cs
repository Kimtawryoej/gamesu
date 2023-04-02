using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TriggerManager : SingleTone<TriggerManager>
{
    ParticleAni particle = new ParticleAni();
    public GameObject attackParticle;
    GameObject MYobject;
    public void  CheackGameObject(GameObject Myobject)
    {
        MYobject = Myobject;
    }
    public  void OnTriggerEnter(Collider other)
    {
        if(MYobject.layer != other.gameObject.layer && other.gameObject.layer != 7 && other.gameObject.layer != 8)
        {
            other.gameObject.GetComponent<Unit>().HpManager(other.gameObject.GetComponent<Unit>().Hp);
            StartCoroutine(particle.Charging(0.5f, other.transform.position, attackParticle, 0));
        }
    }
}
