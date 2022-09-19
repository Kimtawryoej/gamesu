using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public GameObject mushroom;
    GameObject Mush;
    public float maxspeed;
    public int direction = -1;
    Rigidbody2D rid;
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        Mush = Instantiate(mushroom);
        Mush.SetActive(false);
    }
 
}