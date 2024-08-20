using Unity.Entities;
using UnityEngine;

namespace ECS.TheSyedMateen.Popcorn
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public float spawnRate;
    }

    class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new SpawnedModelComponent
            {
                entityPrefab = GetEntity(authoring.objectToSpawn, TransformUsageFlags.Dynamic),
                spawnPosition = authoring.transform.position,
                //nextSpawnTime = 0f,
                //spawnRate = authoring.spawnRate
            });
        }
    }
}