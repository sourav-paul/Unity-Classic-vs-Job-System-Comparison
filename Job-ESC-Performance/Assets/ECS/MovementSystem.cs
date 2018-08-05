using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Example.ECS
{
    public class MovementSystem : JobComponentSystem
    {
        [ComputeJobOptimization]
        struct MovementJob : IJobProcessComponentData<Position,
                                                      Rotation,
                                                      MoveSpeed>
        {
            public float deltaTime;

            public void Execute(ref Position position,
                                [ReadOnly(true)] ref Rotation rotation,
                                [ReadOnly(true)] ref MoveSpeed moveSpeed)
            {
                float3 value = position.Value;

                value += deltaTime *
                         moveSpeed.Value *
                         math.forward(rotation.Value);

                position.Value = value;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MovementJob moveJob = new MovementJob()
            {
                deltaTime = Time.deltaTime
            };

            return moveJob.Schedule(this, 64, inputDeps);
        }
    }
}


