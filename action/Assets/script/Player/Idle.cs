using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle :  IState
{
    private Player player;
    int cnt = 0;
    void IState.OnEnter(Player Player)
    {
        
        this.player = Player;
    }

    void IState.Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            player.SetState(new Run());
        }
        if(Input.GetMouseButtonDown(0))
        {
            player.SetState(new Attack());
        }
       

    }


    void IState.OnExit()
    {//종료되면서 정리해야할것 구현}

    }
}
