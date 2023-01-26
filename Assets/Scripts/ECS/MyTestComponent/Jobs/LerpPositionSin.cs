using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct LerpPositionSin : IJobEntity
    {
        public float Time;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            var ro = myTestComponentAspect
                .myTestComponent
                .ValueRO;

            myTestComponentAspect
                .transformAspect
                .LocalPosition = math.lerp(float3.zero, ro.targetPosition, math.sin(Time));
        }
    }
}
