using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instaite : MonoBehaviour
{
    public GameObject Monster;
    public Camera Camera;
    float tim;
    void OnEnable()
    {
        tim = 0;
        StartCoroutine(monster());
    }
    private void Update()
    {
        tim += Time.deltaTime;
    }
   
    IEnumerator monster()
    {
        WaitForSeconds wait = new WaitForSeconds(7);
        while (tim < 60)
        {
            
            Instantiate(Monster, new Vector3(Random.Range(-27.1f, 44.2f), Random.Range(-5f, 25.6f), 50f), Quaternion.identity);
            yield return wait;
        }
    }
}
