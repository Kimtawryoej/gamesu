using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    GameObject SavePosition;
    RaycastHit2D hitDown;
    RaycastHit2D hitRight;
    LineRenderer lineRenderer;
    float time;
    Vector3 saveposition;
    bool TRUE = true;
    bool True = true;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        while (TRUE)
        {
            transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - (-Input.mousePosition.z)));
            yield return null;
            if (Input.GetMouseButtonDown(0) && hitDown)
            {
                if (hitDown && !hitRight)
                {
                    TRUE = false;
                    lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
                    lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
                   Player.Instance.SavePosition.Add(Instantiate(SavePosition, transform.position, Quaternion.identity));
                    if (transform.position.y < hitDown.collider.gameObject.transform.position.y)
                    {
                        Debug.Log("¸ØÃç");
                        transform.position = new Vector3(transform.position.x, saveposition.y, transform.position.z);
                    }

                }
            }
        }
        //yield return new WaitUntil(() => !TRUE);
        //while(time < 1.5f)
        //{
        //    time +=Time.deltaTime;
        //    lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        //    lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
        //    yield return null;  
        //}
    }
    private void Update()
    {
        hitDown = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, LayerMask.GetMask("Map"));
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.9f, LayerMask.GetMask("Map"));


        if (hitDown && True)
        {
            saveposition = transform.position;
            True = false;
        }
        if (hitRight && TRUE)
        {
            lineRenderer.SetPosition(0, transform.position + new Vector3(1, 0, 0));
            lineRenderer.SetPosition(1, transform.position + new Vector3(1, 3, 0));
        }
        else if (hitDown && TRUE)
        {
            lineRenderer.SetPosition(0, transform.position + new Vector3(0, -1, 0));
            lineRenderer.SetPosition(1, transform.position + new Vector3(3, -1, 0));
            //Debug.Log(hitDown.collider.gameObject.transform.position.y);
            //float Y = Mathf.Clamp(transform.position.y, hitDown.collider.gameObject.transform.position.y, 4.48f);
            //Vector3 dir = new Vector3(transform.position.x, Y, transform.position.z);
            //transform.position = dir;
        }
        else
        {
            lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
            lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
        }

    }
}
