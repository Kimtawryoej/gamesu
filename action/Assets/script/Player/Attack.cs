using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    Animator ani;
    private Player player;
    void IState.OnEnter(Player player)
    {
        this.player = player;
        ani = player.Ani;
        player.StartCoroutine(attack());
    }
    void IState.Update()
    {

    }
    void IState.OnExit()
    {//종료되면서 정리해야할것 구현}


    }


    IEnumerator attack()
    {
            ani.SetBool("isattack", true);
            yield return new WaitForSeconds(0.5f);
            ani.SetBool("isattack", false);
            player.SetState(new Idle());
            Debug.Log("attack1");
    }
}
