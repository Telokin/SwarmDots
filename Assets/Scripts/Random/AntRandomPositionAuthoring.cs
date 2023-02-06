using Unity.Entities;
using Random = Unity.Mathematics.Random;
using UnityEngine;

public class AntRandomPositionAuthoring : MonoBehaviour
{
    public uint randomSeed;
}

public class RandomPositionBaker : Baker<AntRandomPositionAuthoring> 
{
    public override void Bake(AntRandomPositionAuthoring authoring)
    {
        AddComponent(new AntRandomPosition
        {
            value = Random.CreateFromIndex(authoring.randomSeed)
        });
    }
}
