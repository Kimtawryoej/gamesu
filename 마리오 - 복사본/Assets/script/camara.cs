using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mario");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = player.transform.position;
        transform.position = new Vector3(playerpos.x, playerpos.y, transform.position.z);
    }
}
