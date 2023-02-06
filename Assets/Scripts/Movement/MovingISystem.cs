using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct MovingISystem : ISystem
{


    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        float3 antDestination = 0;

        float horizontal = 0;
        float vertical = 0;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            JobHandle jobHandle = new MovePointerJob
            {
                horizontal = horizontal,
                vertical = vertical,
                deltaTime = deltaTime,
            }.ScheduleParallel(state.Dependency);

            jobHandle.Complete();
            foreach (PointerMovementAspect pointerMovement in SystemAPI.Query<PointerMovementAspect>())
            {
                antDestination = pointerMovement.transformAspect.LocalPosition;
            }
        }
        if (Input.GetKey("space"))
        {
            new MoveAntJob
            {
                deltaTime = deltaTime,
                destination = antDestination,
            }.Run();
        }

    }
}


[BurstCompile]
public partial struct MoveAntJob : IJobEntity
{
    public float deltaTime;
    public float3 destination;
    [BurstCompile]
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(deltaTime, destination);
    }
}

public partial struct MovePointerJob : IJobEntity
{
    public float deltaTime;
    public float horizontal;
    public float vertical;
    [BurstCompile]
    public void Execute(PointerMovementAspect pointerMovementAspect)
    {
        pointerMovementAspect.MovePointer(deltaTime, horizontal, vertical);
    }
}
