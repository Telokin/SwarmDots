using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct PointerPositionComponent : IComponentData
{
    public float3 value;
}
