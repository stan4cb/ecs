using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct GoUp : IJobEntity
    {
        public float Delta;

        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            myTestComponentAspect
                .transformAspect
                .LocalPosition += math.up() * Delta;
        }
    }
}
