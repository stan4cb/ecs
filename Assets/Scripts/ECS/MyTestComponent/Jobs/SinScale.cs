using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct SinScale : IJobEntity
    {
        public float Time;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            myTestComponentAspect
                .transformAspect
                .LocalScale = math.sin(Time) * myTestComponentAspect.myTestComponent.ValueRO.targetScale;
        }
    }
}
