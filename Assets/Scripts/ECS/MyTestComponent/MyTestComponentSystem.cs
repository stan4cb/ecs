using Unity.Burst;
using Unity.Entities;

namespace Game
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct MyTestComponentSystem : ISystem
    {
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
            var sceneSetup = SystemAPI.GetSingletonEntity<SceneSetup>();
            var sceneSetupAspect = SystemAPI.GetAspectRW<SceneSetupAspect>(sceneSetup);


            new Jobs.LerpRotationSin
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();

            new Jobs.PositionSinCos
            {
                Time = (float)SystemAPI.Time.ElapsedTime,
                Radius = sceneSetupAspect.sceneSetup.ValueRO.circleRadius,
            }.ScheduleParallel();

            /*new Jobs.GoUp
            {
                Delta = SystemAPI.Time.DeltaTime,
            }
            .ScheduleParallel();
            */

            /*
            new Jobs.LerpPosition
            {
                Delta = SystemAPI.Time.DeltaTime,
            }.ScheduleParallel();
            */

            /*new Jobs.LerpPositionSin
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();
            */

            /*new Jobs.SinScale
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();
            */
        }
    }
}

