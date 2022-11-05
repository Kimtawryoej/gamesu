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
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
           
            player.Change(new Hit());
        }
    }
    public void OnExit()
    {
        
    }
}