using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RandomComponentAuthoring : MonoBehaviour
{
    public class RandomComponentBaker : Baker<RandomComponentAuthoring>
    {
        public override void Bake(RandomComponentAuthoring authoring)
        {
            AddComponent(new RandomComponent() { random = new Unity.Mathematics.Random(1) });
        }
    }
}
