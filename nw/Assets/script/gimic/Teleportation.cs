using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : Connection<Teleportation>
{
    public  static float time;
    int onechance=0;
    int timechance = 0;

    public Teleportation[] teleportation = new Teleportation[2];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(timechance != 0)
        {
            //time += Time.deltaTime;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            time += Time.deltaTime;
            Teleporting.Instance.gameObject.SetActive(true);
            //Debug.Log(time);
            //timechance++;
            if (gameObject.CompareTag("startpos") && time >5)
            {
                time = 0;
                Player.Instance.transform.position = teleportation[1].transform.position;
                //if( onechance ==0)
                //{
                //    Player.Instance.transform.position = teleportation[1].transform.position;
                //    onechance++;
                //    time = 0;
                //}
                //else if(time >10)
                //{
                //    onechance = 0;
                //    time = 0;
                //    timechance = 0;
                //}
            }
            else if (gameObject.CompareTag("endpos") && time > 5)
            {
                time = 0;
                Player.Instance.transform.position = teleportation[0].transform.position;
                //if (onechance == 0)
                //{
                //    Player.Instance.transform.position = teleportation[0].transform.position;
                //    onechance++;
                //}
                //else if (time > 10)
                //{
                //    onechance = 0;
                //    time = 0;
                //    timechance = 0;
                //}
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            time = 0;
            Teleporting.Instance.gameObject.SetActive(false);
        }
    }
}
