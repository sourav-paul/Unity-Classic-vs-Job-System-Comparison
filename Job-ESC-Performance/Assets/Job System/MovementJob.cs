using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;

namespace Example.JobSystem
{
    [ComputeJobOptimization]
    public struct MovementJob : IJobParallelForTransform
    {
        public float moveSpeed;
        public float deltaTime;

        public void Execute(int index,
                            TransformAccess transform)
        {
            Vector3 pos = transform.position;
            pos += (transform.rotation * Vector3.up) *
                    moveSpeed *
                    deltaTime;

            transform.position = pos;
        }
    }
}
