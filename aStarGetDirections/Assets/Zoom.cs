using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float speed = 10.0f;
    private float temp_value;
    Camera Camera;

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        // scroll < 0 : scroll down하면 줌인
        if (Camera.orthographicSize <= 2.67f && scroll > 0)
        {
            temp_value = Camera.orthographicSize;
            Camera.orthographicSize = temp_value; // maximize zoom in

            // 최대로 Zoom in 했을 때 특정 값을 지정했을 때

            // 최대 줌 인 범위를 벗어날 때 값에 맞추려고 한번 줌 아웃 되는 현상을 방지
        }

        // scroll > 0 : scroll up하면 줌아웃
        else if (Camera.orthographicSize >= 7.03f && scroll < 0)
        {
            temp_value = Camera.orthographicSize;
            Camera.orthographicSize = temp_value; // maximize zoom out
        }
        else
            Camera.orthographicSize -= scroll * 0.5f;
    }
}
