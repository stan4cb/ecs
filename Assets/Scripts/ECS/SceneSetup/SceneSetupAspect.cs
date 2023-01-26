using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public readonly partial struct SceneSetupAspect : IAspect
{
    public readonly Entity entity;

    public readonly TransformAspect transformAspect;

    public readonly RefRO<SceneSetup> sceneSetup;
    public readonly RefRW<SceneSetupRandom> random;
}
