using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaging : MonoBehaviour
{
    public static Chaging Instance;
    [SerializeField]
    GameObject Raser;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(des());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(2);
        Instantiate(Raser, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(Raser, transform.position, Quaternion.Euler(0, 90, 0));
        gameObject.SetActive(false);
    }
}
