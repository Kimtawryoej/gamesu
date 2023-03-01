using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zoom : MonoBehaviour
{
    Vector2 move;
    float mouse;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                   Input.mousePosition.y, -Camera.main.transform.position.z));
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            gameObject.transform.position += new Vector3(0, 0, 0.1f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            gameObject.transform.position -= new Vector3(0, 0, 0.1f);
        }
        //if (Input.GetMouseButton(0))
        //{
        //    move.x = Input.GetAxis("Mouse X");
        //    move.y = Input.GetAxis("Mouse Y");
        //    Debug.Log(move.x);
        //    transform.rotation = Quaternion.Euler(move.y * 30, move.x * 30, 0);
        //}
    }
}
