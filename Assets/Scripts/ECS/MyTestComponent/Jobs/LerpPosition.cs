using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct LerpPosition : IJobEntity
    {
        public float Delta;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            var ro = myTestComponentAspect
                .myTestComponent
                .ValueRO;

            if (ro.isForward && ro.currentTimePosition >= ro.maxTimePosition)
            {
                myTestComponentAspect
                    .myTestComponent
                    .ValueRW.isForward = false;
            }

            if (!ro.isForward && ro.currentTimePosition <= 0)
            {
                myTestComponentAspect
                    .myTestComponent
                    .ValueRW.isForward = true;
            }

            var lerp = ro.currentTimePosition + (ro.isForward ? Delta : -Delta);

            myTestComponentAspect
                .myTestComponent
                .ValueRW
                .currentTimePosition = lerp;

            lerp = lerp / myTestComponentAspect
                .myTestComponent
                .ValueRO.maxTimePosition;

            myTestComponentAspect
                .transformAspect
                .LocalPosition = math.lerp(float3.zero, ro.targetPosition, lerp);
        }
    }
}
