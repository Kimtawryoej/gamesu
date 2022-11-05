using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Run : ISTATe
{
    private Player player;
    float speed = 8f;
    public void OnEnter(Player player)
    {
        this.player = player;
    }
    public void Update()
    {


        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        player.transform.position += dir * speed * Time.deltaTime;
     
        if (!Input.GetButtonDown("Horizontal") && !Input.GetButtonDown("Vertical"))
        {
            player.Change(new Idle());
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            player.Change(new Hit());
        }
    }
    public void OnExit()
    {

    }
}
