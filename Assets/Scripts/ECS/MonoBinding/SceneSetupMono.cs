using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SceneSetupMono : MonoBehaviour
{
    public int spawnCount = 100;

    public float2 scale;

    public float3 min, max;

    public GameObject toSpawn;
    
    public class SceneSetupBaker : Baker<SceneSetupMono>
    {
        public override void Bake(SceneSetupMono authoring)
        {
            AddComponent(new SceneSetup
            {
                spawnCount = authoring.spawnCount,

                scale = authoring.scale,

                min = authoring.min,
                max = authoring.max,

                toSpawn = GetEntity(authoring.toSpawn)
            });

            AddComponent(new SceneSetupRandom
            {
                myRandom = Unity.Mathematics.Random.CreateFromIndex((uint)UnityEngine.Random.Range(uint.MinValue, uint.MaxValue))
            });
        }
    }
}