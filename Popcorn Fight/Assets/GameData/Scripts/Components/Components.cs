using Unity.Entities;
using Unity.Mathematics;

namespace ECS.TheSyedMateen.Popcorn
{
    public struct PlayerTargetPosition : IComponentData
    {
        public float3 value;
    }

    public struct PlayerTag : IComponentData
    { }
}
