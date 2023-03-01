using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire Instance;
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StartCoroutine(fire());
    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            transform.position = other.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("¥Í¿Ω");
        if (other.CompareTag("Monster"))
        {
            transform.position = other.transform.position;
        }
    }


}
