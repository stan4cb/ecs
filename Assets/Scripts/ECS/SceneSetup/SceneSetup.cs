using Unity.Entities;
using Unity.Mathematics;

public struct SceneSetup : IComponentData
{
    public int spawnCount;

    public float2 scale;

    public float3 min, max;

    public Entity toSpawn;
}
