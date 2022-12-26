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
        
  
       
     
        if (!Input.GetButtonDown("Horizontal") && !Input.GetButtonDown("Vertical"))
        {
            player.Change(new Idle());
        }
        if (Input.GetButton("Jump"))
        {
            
            player.Change(new Hit());
         
        }
         
       


    }


   

    public void OnExit()
    {

    }
}
