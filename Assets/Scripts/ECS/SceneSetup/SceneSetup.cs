using Unity.Entities;
using Unity.Mathematics;

public struct SceneSetup : IComponentData
{
    public int spawnCount;

    public float spawnRadius;
    public float2 scale;

    public float circleRadius;

    public Entity toSpawn;
}
