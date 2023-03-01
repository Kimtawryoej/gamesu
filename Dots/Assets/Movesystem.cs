using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
using System;
using Random = Unity.Mathematics.Random;

public partial class Movesystem : SystemBase
{
    protected override void OnUpdate()
    {
        
        float deltatime = SystemAPI.Time.DeltaTime;
        foreach(MoveToTarget moveToTarget  in SystemAPI.Query<MoveToTarget>())
        {
            moveToTarget.move(deltatime);
        }
    }

  
}
