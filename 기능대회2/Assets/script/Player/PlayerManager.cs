using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    float tim;

    void OnEnable()
    {
        tim = 0;
        transform.position = new Vector3(3.654122f, 1.414869f, 12.70118f);
        //gameObject.GetComponent<Animator>().enabled = true;
        Debug.Log("WWW");
        StartCoroutine(changeMove());
    }
    private void Update()
    {
        tim += Time.deltaTime;
    }
    IEnumerator changeMove()
    {
        yield return new WaitUntil(() => tim >= 60 && SceneManager.GetActiveScene().name == "SampleScene");
        gameObject.GetComponent<Animator>().enabled = false;
        Debug.Log("¹ßµ¿");
        transform.position = new Vector3(-9.7f, -48.6f, -17.8f);

    }
}
