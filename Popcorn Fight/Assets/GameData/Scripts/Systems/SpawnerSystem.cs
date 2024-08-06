using Unity.Burst;
using Unity.Entities;
using Unity.Collections;


namespace ECS.TheSyedMateen.Popcorn
{
    [BurstCompile]
    public partial struct SpawnerSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if(!SystemAPI.TryGetSingletonEntity<SpawnedModelComponent>(out Entity spawnerEntity))
            {
                return;
            }

            RefRW<SpawnedModelComponent> spawner = SystemAPI.GetComponentRW<SpawnedModelComponent>(spawnerEntity);

            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

            if(spawner.ValueRO.nextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                Entity entity = ecb.Instantiate(spawner.ValueRO.entityPrefab);

                ecb.AddComponent(entity, new MovementComponent
                {
                    moveDirection = Unity.Mathematics.Random.CreateFromIndex((uint)(SystemAPI.Time.ElapsedTime / SystemAPI.Time.DeltaTime)).NextFloat3(),
                    moveSpeed = 10f
                });
                spawner.ValueRW.nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.spawnRate;

                ecb.Playback(state.EntityManager);
            }
        }
    }
}
