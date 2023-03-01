using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MoveToTarget : IAspect
{
    public readonly Entity entity;
    public readonly TransformAspect transformAspect;
    public readonly RefRO<Speed> speed;
    public readonly RefRW<Movetarget> moveTarget;
  public void move(float deltatime)
    {
        float3 direction = moveTarget.ValueRO.targetPosition - transformAspect.Position;
        float3 delta = math.normalize(direction) * speed.ValueRO.value * deltatime;
        transformAspect.Position += delta;
        float distane = direction.x + direction.x + direction.y * direction.y + direction.z + direction.z * direction.z;
        if (distane < 0.5f)
        {
            moveTarget.ValueRW.targetPosition = GetTargetPosition();
        }
    }

    private float3 GetTargetPosition()
    {
        return new float3
            (
             UnityEngine.Random.Range(0f, 15f),
              0,
             UnityEngine.Random.Range(0f, 15f)
            );
    }
}
