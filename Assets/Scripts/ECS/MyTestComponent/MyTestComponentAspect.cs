using Unity.Entities;
using Unity.Transforms;

//using Unity.Entities.Graphics;

namespace Game
{
    public readonly partial struct MyTestComponentAspect : IAspect
    {
        public readonly Entity entity;
        public readonly TransformAspect transformAspect;

        public readonly RefRW<MyTestComponent> myTestComponent;
        //public readonly RefRW<RenderFilterSettings> renderer;
    }
}