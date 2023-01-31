using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Game
{
    [BurstCompile]
    [CreateAfter(typeof(SceneSetup))]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct MyTestComponentSystem : ISystem
    {
        public bool isForward;

        public double lastPressedTime;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MyTestComponent>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state) { }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var time = SystemAPI.Time.ElapsedTime;

            if (!isForward)
                time -= lastPressedTime;

            var sceneSetup = SystemAPI.GetSingletonEntity<SceneSetup>();
            var sceneSetupAspect = SystemAPI.GetAspectRW<SceneSetupAspect>(sceneSetup);

            new Jobs.Rotation
            {
                Delta = SystemAPI.Time.DeltaTime
            }
            .ScheduleParallel();

            new Jobs.PositionSinCos
            {
                Time = (float)time,
                Radius = sceneSetupAspect.sceneSetup.ValueRO.circleRadius,
            }.ScheduleParallel();

            new Jobs.ColorChanger
            {
                Time = (float)time,
                Radius = sceneSetupAspect.sceneSetup.ValueRO.circleRadius,
            }.ScheduleParallel();
        }
    }
}

