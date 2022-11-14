using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : ISTATe
{
    private Player player;
    public void OnEnter(Player player)
    {
        this.player = player;
    }
    public void Update()
    {
        
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            
            player.Change(new Run());
        }
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
           
            player.Change(new Hit());
        }
    }
    public void OnExit()
    {
        
    }
}