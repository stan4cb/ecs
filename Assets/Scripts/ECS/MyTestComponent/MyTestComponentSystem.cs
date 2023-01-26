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

            new Jobs.LerpRotationSin
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();

            new Jobs.LerpPositionSin
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();

            new Jobs.SinScale
            {
                Time = (float)SystemAPI.Time.ElapsedTime
            }
            .ScheduleParallel();
        }
    }
}

