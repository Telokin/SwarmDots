using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{

    private readonly TransformAspect transformAspect;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime, float3 destination)
    {
        //targetPosition.ValueRW.value = aimovement.ValueRO.destination;
        targetPosition.ValueRW.value = destination;
        float3 direction = math.normalize(targetPosition.ValueRW.value - transformAspect.LocalPosition);
        transformAspect.LocalPosition += direction * deltaTime * speed.ValueRO.value;
    }
}
