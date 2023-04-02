using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raser : MonoBehaviour
{
    Raser[] RAser;
    void Start()
    {
        StartCoroutine(des());
        if (Bos.Instance.patteren == 1)
        {
            transform.SetParent(Bos.Instance.transform);
            RAser = FindObjectsOfType<Raser>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Bos.Instance.patteren == 1)
        {
            RAser[0].gameObject.transform.rotation = Quaternion.Euler(0, Time.time * -25, 0);
            RAser[1].gameObject.transform.rotation = Quaternion.Euler(0, Time.time * 25, 0);
        }
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(5);
        if (Bos.Instance.patteren != 1)
            Destroy(gameObject);
        else if (Bos.Instance.patteren == 1)
        { yield return new WaitForSeconds(2); Destroy(gameObject);  Debug.Log("∑π¿Ã¿˙"); }
    }
    //IEnumerator des()
    //{
    //    yield return new WaitForSeconds(2);
    //    Destroy(gameObject);
    //}
}
