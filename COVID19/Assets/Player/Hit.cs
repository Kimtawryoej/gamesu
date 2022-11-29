using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Hit : ISTATe
{
    static Hit Instance;
    Bullet bullet = new Bullet();
    private Player player;
    public GameObject gameobject;

    



    public void OnEnter(Player player)
    {

        Instance = this;
        //Debug.Log(player);
        this.player = player;
        player.StartCoroutine(bulle());

    }


    

    public void Update()
    {


    }

    private IEnumerator bulle()
    {
        ObjectPool.Instance.GetObject(this.player.prefab, this.player.transform.position, this.player.quaternion);


        for (int b = 1; b < Public.Instance.leavel; b++)
        {
            ObjectPool.Instance.GetObject(this.player.prefab, this.player.transform.position, Quaternion.AngleAxis(10 * b, Vector3.forward));
            ObjectPool.Instance.GetObject(this.player.prefab, this.player.transform.position, Quaternion.AngleAxis(-10 * b, Vector3.forward));
        }
        ObjectPool.Instance.GetObject(Player.Instance.prefab2, bullet2.Instance.circlePoint);

        yield return new WaitForSeconds(0.3f);
        player.Change(new Run());

    }

    

      
    
    public void OnExit()
    {

    }



}
