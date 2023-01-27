using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct Rotation : IJobEntity
    {
        public float Delta;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            var ro = myTestComponentAspect
                .myTestComponent
                .ValueRO;
        }
    }
}
