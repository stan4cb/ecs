using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SceneSetupMono : MonoBehaviour
{
    public int spawnCount = 100;

    public float spawnRadius;

    public float2 scale;

    public float circleRadius;

    public GameObject toSpawn;
    
    public class SceneSetupBaker : Baker<SceneSetupMono>
    {
        public override void Bake(SceneSetupMono authoring)
        {
            AddComponent(new SceneSetup
            {
                spawnCount = authoring.spawnCount,

                scale = authoring.scale,

                spawnRadius = authoring.spawnRadius,

                circleRadius = authoring.circleRadius,

                toSpawn = GetEntity(authoring.toSpawn)
            });

            AddComponent(new SceneSetupRandom
            {
                myRandom = Unity.Mathematics.Random.CreateFromIndex((uint)UnityEngine.Random.Range(uint.MinValue, uint.MaxValue))
            });
        }
    }
}