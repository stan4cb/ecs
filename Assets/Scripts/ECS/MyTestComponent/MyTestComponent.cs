using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public partial struct MyTestComponent : IComponentData
    {
        public float currentTimePosition;
        public float maxTimePosition;

        public bool isForward;

        public float targetScale;
        public float3 targetPosition;
        public quaternion targetRotation;
    }
}

