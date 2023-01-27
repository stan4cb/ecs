using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

// "_MyColor" refers to the reference we overrode previously
[MaterialProperty("_MyColor")]
public struct MyColorComponent : IComponentData
{
    public float4 Value;
}
