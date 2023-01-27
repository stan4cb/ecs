using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct SceneSetupSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SceneSetup>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var sceneSetup = SystemAPI.GetSingletonEntity<SceneSetup>();
        var sceneSetupAspect = SystemAPI.GetAspectRW<SceneSetupAspect>(sceneSetup);

        var roScene = sceneSetupAspect.sceneSetup.ValueRO;

        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        for (int i = 0; i < sceneSetupAspect.sceneSetup.ValueRO.spawnCount; i++)
        {
            var entity = ecb.Instantiate(sceneSetupAspect.sceneSetup.ValueRO.toSpawn);

            var mtComponent = new Game.MyTestComponent
            {
                currentTimePosition = 0,
                maxTimePosition = 1,

                isForward = true,

                targetPosition = sceneSetupAspect.random.ValueRW.myRandom.NextFloat3Direction() * roScene.spawnRadius,
                targetScale = sceneSetupAspect.random.ValueRW.myRandom.NextFloat(roScene.scale.x, roScene.scale.y),
                targetRotation = sceneSetupAspect.random.ValueRW.myRandom.NextQuaternionRotation(),
            };

            ecb.AddComponent(entity, mtComponent);

            ecb.SetComponent(entity,
                new Unity.Transforms.LocalTransform
                {
                    //Position = float3.zero,
                    Position = mtComponent.targetPosition,
                    Rotation = sceneSetupAspect.random.ValueRW.myRandom.NextQuaternionRotation(),
                    Scale = mtComponent.targetScale,
                    //Scale = 0f,
                });
        }

        ecb.Playback(state.EntityManager);
    }
}
