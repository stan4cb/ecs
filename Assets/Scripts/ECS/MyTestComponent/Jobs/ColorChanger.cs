using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct ColorChanger : IJobEntity
    {
        public float Time;

        public float Radius;

        [BurstCompile]
        private void Execute(ref MyColorComponent materialColor, in LocalTransform localTransform)
        {
            //materialColor = new MaterialColor( new float4(localTransform.Position, 1);
        }
    }
}
