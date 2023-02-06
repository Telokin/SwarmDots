using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PointerPositionAuthoring : MonoBehaviour
{
    public float3 value;
}

public class PointerPositionBaker : Baker<PointerPositionAuthoring>
{
    public override void Bake(PointerPositionAuthoring authoring)
    {
        AddComponent(new PointerPositionComponent
        {
            value= authoring.value
        });
    }
}
