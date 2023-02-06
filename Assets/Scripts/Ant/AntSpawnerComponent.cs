using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct AntSpawnerComponent : IComponentData
{
    public int antToSpawn;

    public Entity groundAntPrefab;

    public float2 fieldDimensions;

    //public Entity airAntPrefab;

    //public Entity waterAntPrefab;
}


