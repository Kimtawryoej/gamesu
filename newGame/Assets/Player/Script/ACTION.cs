using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - (-Input.mousePosition.z)));
            yield return null;
        }
        yield return new WaitUntil(()=> Input.GetMouseButtonDown(0));
        transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - (-Input.mousePosition.z)));
    }
}
