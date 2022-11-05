using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Hit : ISTATe
{
    Bullet bullet = new Bullet();
    private Player player;
    public GameObject gameobject;
    public void OnEnter(Player player)
    {
        //Debug.Log(player);
        this.player = player;

        ObjectPool.Instance.GetObject(this.player.prefab, this.player.transform.position, this.player.quaternion);

        this.player.Change(new Run());
    }

    public void Update()
    {


    }
    public void OnExit()
    {

    }



}
