using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class AntSpawnerAuthoring : MonoBehaviour
{
    public GameObject groundAntPrefab;

    public int antToSpawn;

    public float2 fieldDimensions;
    //public GameObject airAntPrefab;

    //public GameObject waterAntPrefab;
}

public class AntSpawnerBaker : Baker<AntSpawnerAuthoring>
{
    public override void Bake(AntSpawnerAuthoring authoring)
    {
        AddComponent(new AntSpawnerComponent
        {
            groundAntPrefab = GetEntity(authoring.groundAntPrefab),
            antToSpawn = authoring.antToSpawn,
            fieldDimensions = authoring.fieldDimensions,
            //airAntPrefab = GetEntity(authoring.airAntPrefab),
            //waterAntPrefab = GetEntity(authoring.waterAntPrefab),
        });
    }
}
