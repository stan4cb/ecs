using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct PositionSinCos : IJobEntity
    {
        public float Time;

        public float Radius;

        [BurstCompile]
        private void Execute(ref LocalTransform localTransform, in MyTestComponent mtc)
        {
            localTransform = localTransform.WithPosition(new float3
            {
                x = mtc.targetPosition.x + math.sin(Time) * Radius,
                y = mtc.targetPosition.y + math.cos(Time) * Radius,
                z = mtc.targetPosition.z + math.tan(Time * .5f) * Radius
            });
        }
    }
}
