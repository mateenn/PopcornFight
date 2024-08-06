using Unity.Entities;
using Unity.Mathematics;

namespace ECS.TheSyedMateen.Popcorn
{
    public struct MovementComponent : IComponentData
    {
        public float3 moveDirection;
        public float moveSpeed;
    }
}
