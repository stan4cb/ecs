using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Game.Jobs
{
    [BurstCompile]
    public partial struct Rotation : IJobEntity
    {
        public float Delta;

        // Aspect Way
        /*
        [BurstCompile]
        private void Execute(MyTestComponentAspect myTestComponentAspect)
        {
            UnityEngine.Debug.Log("Execute");

            var ro = myTestComponentAspect
                .myTestComponent
                .ValueRO;

            var rotation = myTestComponentAspect.transformAspect.LocalRotation;
            var rotated = math.rotate(rotation, ro.targetPosition * Delta);

            myTestComponentAspect
                .transformAspect
                .RotateLocal( quaternion.Euler(rotated));
        }
        */

        // match way
        [BurstCompile]
        private void Execute(ref LocalTransform localTransform, in MyTestComponent myTestComponent)
        {
            var rotation = localTransform.Rotation;
            var rotated = math.rotate(rotation, myTestComponent.targetPosition * Delta);

            localTransform = localTransform.Rotate(quaternion.Euler(rotated));
        }
    }
}
