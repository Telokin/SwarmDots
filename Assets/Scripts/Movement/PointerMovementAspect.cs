using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public readonly partial struct PointerMovementAspect : IAspect
{
    public readonly TransformAspect transformAspect;
    public readonly RefRO<Speed> speed;
    public readonly RefRW<PointerPositionComponent> pointerPosition;


    public void MovePointer(float deltaTime, float horizontal, float vertical)
    {
        transformAspect.LocalPosition += new float3(horizontal, 0f, vertical) * deltaTime * speed.ValueRO.value;
    }
}
