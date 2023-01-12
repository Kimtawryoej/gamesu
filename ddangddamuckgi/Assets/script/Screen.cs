using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoSingleton<Screen>
{
    SpriteRenderer mainSprite;

    [SerializeField] private RawImage originalImage;
    [SerializeField] private RawImage cropArea;
    int a = 0;
    int b = 0;
    [SerializeField] LayerMask layerMask;
    int[] number = new int[2];
    public GameObject prefab;
    public float xMin, xMax, yMin, yMax;

    Vector3[] coordinate = new Vector3[10000];

    float h;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        //mainSprite.sprite.texture.SetPixel( , , new Color(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(x, y, transform.position.z);

        h = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (Input.GetButton("Horizontal"))
        {
            int speed = 2;
            Vector3 dir = new Vector3(h, 0, 0);
            transform.position += dir * speed * Time.deltaTime;
            ObjectPool.instance.Pool2(prefab, transform.position);
        }

        else if (Input.GetButton("Vertical"))
        {
            int speed = 2;
            Vector3 dir = new Vector3(0, z, 0);
            transform.position += dir * speed * Time.deltaTime;
            ObjectPool.instance.Pool2(prefab, transform.position, Quaternion.AngleAxis(90, Vector3.forward));
        }


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 3, layerMask);


        if (!hit.collider && a == 0)
        {
            coordinate[0] = transform.position;
            Debug.Log("³¡");
            a = 1;
        }
        if (!hit.collider && transform.position.x != coordinate[0].x && b == 0)
        {
            coordinate[1] = Camera.main.WorldToScreenPoint(transform.position);
            Debug.Log("³¡2");
            b = 1;


        }
        if (hit.collider && a == 1 && b != 1)
        {

            for (int i = 2; i < coordinate.Length; i++)
            {

                if (coordinate[i] == new Vector3(0, 0, 0) && h != 0 || z != 0)
                {
                    coordinate[i] = Camera.main.WorldToScreenPoint(transform.position);
                    Debug.Log(coordinate[i]);
                    break;
                }
            }
        }

    }

    //void floodfill()
    //{

    //    for (int i = 0; i < coordinate.Length; i++)
    //    {
    //        coordinate[2].x++;
    //        if(coordinate[2].x++)
    //    }
    //    coordinate[2].x--;
    //}
}
