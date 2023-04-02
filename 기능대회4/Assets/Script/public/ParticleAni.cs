using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAni : MonoBehaviour
{
    public IEnumerator Charging(float Time, Vector3 Myposition, GameObject PArticle, float Angle)
    {
        GameObject Particle = Instantiate(PArticle, Myposition, Quaternion.Euler(90, 0, 0));
        yield return new WaitForSeconds(Time);
        Destroy(Particle);
    }
}
