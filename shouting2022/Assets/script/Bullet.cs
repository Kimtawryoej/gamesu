using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string key;
    // Start is called before the first frame update
     IEnumerator C_Move() //ÄÚ·çÆ¾
    {
        for(float t =0; t<3; t +=Time.deltaTime)
        {
            transform.Translate(new Vector2(0,1) * Time.deltaTime * 10); 
            yield return null;
        }
        PoolingManager.Instance.ReturnBullet(key, this);
    }

    private void OnEnable()
    {
        StartCoroutine(C_Move());
    }

}
