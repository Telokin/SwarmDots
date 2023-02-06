using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct AntSpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<AntSpawnerComponent>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var antEntity = SystemAPI.GetSingletonEntity<AntSpawnerComponent>();
        var ant = SystemAPI.GetAspectRW<AntAspect>(antEntity);

        var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);

        for(var i = 0; i < ant.antAmount; i++)
        {
            var newAnt = entityCommandBuffer.Instantiate(ant.groundAntPrefab);
            var newAntTransform = ant.GetRandomAntTransform();
            entityCommandBuffer.SetComponent(newAnt, newAntTransform);
        }

        entityCommandBuffer.Playback(state.EntityManager);
    }
}
