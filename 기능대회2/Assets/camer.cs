using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camer : SingleTone<camer>
{
    float tim;
    public Animator animator;
    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        tim = 0;
        Debug.Log("È¸Àü");
        animator = GetComponent<Animator>();
        base.Awake();
        StartCoroutine(cameraposition());
    }
    private void Update()
    {
        tim += Time.deltaTime;
    }
    IEnumerator cameraposition()
    {
        yield return new WaitUntil(()=> tim >= 60 && SceneManager.GetActiveScene().name == "SampleScene");
        transform.rotation = Quaternion.Euler(90, 0, 0);
        //yield return new WaitUntil(() => SceneManager.GetActiveScene().name ==  "Stage2");
        //transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
