using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;
using Unity.VisualScripting.FullSerializer;
using static UnityEngine.EventSystems.EventTrigger;

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

        var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        var spawned = CollectionHelper.CreateNativeArray<Entity>(roScene.spawnCount, Allocator.Temp);

        ecb.Instantiate(roScene.toSpawn, spawned);

        foreach (var entity in spawned)
        {
            var mtComponent = new Game.MyTestComponent
            {
                currentTimePosition = 0,
                maxTimePosition = 1,

                isForward = true,

                targetPosition = sceneSetupAspect.random.ValueRW.myRandom.NextFloat3Direction() * roScene.spawnRadius,
                targetScale = sceneSetupAspect.random.ValueRW.myRandom.NextFloat(roScene.scale.x, roScene.scale.y),
                targetRotation = sceneSetupAspect.random.ValueRW.myRandom.NextQuaternionRotation(),
            };

            //var randomColorComp = new ;

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

            //ecb.AddComponentForLinkedEntityGroup<>
        }

        /*

        var all_entities = state.EntityManager.GetAllEntities(Unity.Collections.Allocator.Temp);

        foreach(var entity in all_entities)
        {
            var buffer = SystemAPI.GetBuffer<Child>(entity);

            foreach (var b in buffer)
            {
                Unity.Logging.Log.Debug("Buffer", b);
            }
        }
        */
    }
}
