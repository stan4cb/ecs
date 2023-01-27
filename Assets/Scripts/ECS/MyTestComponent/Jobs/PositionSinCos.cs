using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct PositionSinCos : IJobEntity
    {
        public float Time;

        public float Radius;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            var ro = myTestComponentAspect
                .myTestComponent
                .ValueRO;

            myTestComponentAspect
                .transformAspect
                .LocalPosition = new float3 {
                    x = ro.targetPosition.x + math.sin(Time) * Radius,
                    y = ro.targetPosition.y + math.cos(Time) * Radius,
                    z = ro.targetPosition.z // + math.tan(Time) * Radius
                };
        }
    }
}
