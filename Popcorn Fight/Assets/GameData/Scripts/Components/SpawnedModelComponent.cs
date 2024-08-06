using Unity.Entities;
using Unity.Mathematics;
namespace ECS.TheSyedMateen.Popcorn
{
    public struct SpawnedModelComponent : IComponentData
    {
        public Entity entityPrefab;
        public float3 spawnPosition;
        public float nextSpawnTime;
        public float spawnRate;
    }
}