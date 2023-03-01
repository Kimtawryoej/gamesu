using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MovertargetAuthoring : MonoBehaviour
{
   
}
public class MovetargetBaker : Baker<MovertargetAuthoring>
{
    public override void Bake(MovertargetAuthoring authoring)
    {
        AddComponent(new Movetarget());
    }
}
