using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace ECS.TheSyedMateen.Popcorn
{
    [BurstCompile]
    public partial struct PlayerSpawnerSystem : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {

            if (SystemAPI.TryGetSingletonEntity<PlayerTag>(out _))
            {
                // A player has already been spawned, so we return without doing anything
                return;
            }
            if (!SystemAPI.TryGetSingletonEntity<SpawnedModelComponent>(out Entity spawnerEntity))
            {
                return;
            }
            RefRW<SpawnedModelComponent> spawner = SystemAPI.GetComponentRW<SpawnedModelComponent>(spawnerEntity);
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

            Entity entity = ecb.Instantiate(spawner.ValueRO.entityPrefab);
            ecb.AddComponent(entity, new PlayerTag { });
            ecb.AddComponent(entity, new PlayerTargetPosition { value = float3.zero });
            ecb.AddComponent(entity, new MovementComponent {moveSpeed = 1 });
            ecb.Playback(state.EntityManager);
        }
    }
}
