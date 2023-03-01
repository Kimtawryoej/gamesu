using Unity.Entities;

public struct Speed : IComponentData
{
    public float value;
    public Speed(float value)
    {
        this.value = value;
    }
}
