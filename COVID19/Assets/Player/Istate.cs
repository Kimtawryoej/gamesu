using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



public interface ISTATe
{
    public void OnEnter(Player player);
    public void Update();
    public void OnExit();
}
