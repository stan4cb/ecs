using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct LerpRotationSin : IJobEntity
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
                .LocalRotation = math.slerp(quaternion.identity, ro.targetRotation, math.sin(Time));
        }
    }
}
