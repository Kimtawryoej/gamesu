using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ISTATe CurrentState;
   public   Vector3 position;
    public  Quaternion quaternion;
    public GameObject prefab;
    public float Xmax, Xmin,Ymax,Ymin;

    Collider2D collider;
    float speed = 3f;
    void Start()
    {
        Change(new Idle());
        collider = GetComponent<Collider2D>();
        position = new Vector3(transform.position.x, transform.position.y, 0);
        quaternion = transform.rotation;
    }

     void Update()
    {
        CurrentState.Update();
       float x = Mathf.Clamp(transform.position.x,Xmin,Xmax);
        float y = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(x, y, transform.position.z);
    }
    public void Change(ISTATe chan)
    {
        if(CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = chan;
       
        CurrentState.OnEnter(this);
        
    }

}
