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
        player.StartCoroutine(A());
    }
    void IState.Update()
    {

    }
    void IState.OnExit()
    {//����Ǹ鼭 �����ؾ��Ұ� ����}


    }


    IEnumerator A()
    {
            ani.SetBool("isattack", true);
            //Run.Instance.speed = 0;
            yield return new WaitForSeconds(0.5f);
            ani.SetBool("isattack", false);
            player.SetState(new Idle());
            Debug.Log("attack1");
    }
}
