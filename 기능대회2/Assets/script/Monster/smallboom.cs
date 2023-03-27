using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallboom : MonoBehaviour
{
   Animator animator;

    private void Start()
    {
        StartCoroutine(des());
    }
   IEnumerator des()
    {
        yield return new WaitForSeconds(2.2f);
        Destroy(gameObject);
    }
}
