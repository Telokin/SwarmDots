using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct AntAspect : IAspect
{
    public readonly Entity entity;

    private readonly TransformAspect _transformAspect;

    private readonly RefRO<AntSpawnerComponent> _antSpawnerComponent;

    private readonly RefRW<AntRandomPosition> _antRandomPosition;

    public int antAmount => _antSpawnerComponent.ValueRO.antToSpawn;

    public Entity groundAntPrefab => _antSpawnerComponent.ValueRO.groundAntPrefab;

    public LocalTransform GetRandomAntTransform()
    {
        return new LocalTransform
        {
            Position = GetRandomPosition(),
            Rotation = quaternion.identity,
            Scale = 1f,
        };
    }

    private float3 GetRandomPosition()
    {
        float3 randomPosition;

        randomPosition = _antRandomPosition.ValueRW.value.NextFloat3(MinCorner, MaxCorner);
        return randomPosition;
    }

    private float3 MinCorner => _transformAspect.LocalPosition - HalfDimensions;
    private float3 MaxCorner => _transformAspect.LocalPosition + HalfDimensions;

    private float3 HalfDimensions => new()
    {
        x = _antSpawnerComponent.ValueRO.fieldDimensions.x * 0.5f,
        y = 0f,
        z = _antSpawnerComponent.ValueRO.fieldDimensions.y * 0.5f
    };
}
