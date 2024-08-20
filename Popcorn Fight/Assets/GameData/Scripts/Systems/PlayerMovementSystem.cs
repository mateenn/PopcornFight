using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.TheSyedMateen.Popcorn
{
    [BurstCompile]

    public partial struct PlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityManager entityManager = state.EntityManager;
            Entity playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();

            if (entityManager.HasComponent<MovementComponent>(playerEntity))
            {
                MovementComponent movementComponent = entityManager.GetComponentData<MovementComponent>(playerEntity);
                LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(playerEntity);
                PlayerTargetPosition playerTargetPosition = entityManager.GetComponentData<PlayerTargetPosition>(playerEntity);

                float3 moveDirection = playerTargetPosition.value - localTransform.Position;

                float3 nextPosition = moveDirection * SystemAPI.Time.DeltaTime * movementComponent.moveSpeed;

                localTransform.Position += nextPosition;

                entityManager.SetComponentData<LocalTransform>(playerEntity, localTransform);

                /* float3 moveDirection = playerTargetPosition.value - localTransform.Position;
                 float distance = math.length(moveDirection);

                 if (distance > 0.1f) // Adjust this threshold as needed
                 {
                     moveDirection = math.normalize(moveDirection);
                     float3 nextPosition = moveDirection * SystemAPI.Time.DeltaTime * movementComponent.moveSpeed;

                     // Ensure the player does not overshoot the target position
                     if (math.length(nextPosition) > distance)
                     {
                         nextPosition = playerTargetPosition.value - localTransform.Position;
                     }

                     localTransform.Position += nextPosition;

                     entityManager.SetComponentData(playerEntity, localTransform);
                 }*/
            }
        }
    }
}
