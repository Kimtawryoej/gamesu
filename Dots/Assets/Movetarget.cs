using Unity.Entities;
using Unity.Mathematics;

public struct Movetarget : IComponentData
{
    public float3 targetPosition;
    public Movetarget(float targetposition)
    {
        this.targetPosition = targetposition;
    }
}
