using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


namespace ECS.TheSyedMateen.Popcorn
{
    [BurstCompile]
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
           /* EntityManager entityManager = state.EntityManager;
            NativeArray<Entity> movementEntities = entityManager.GetAllEntities(Allocator.Temp);

            foreach(Entity entity in movementEntities)
            {
                if(entityManager.HasComponent<MovementComponent>(entity))
                {
                    MovementComponent movementComponent = entityManager.GetComponentData<MovementComponent>(entity);
                    LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(entity);


                    float3 nextPosition = movementComponent.moveDirection * SystemAPI.Time.DeltaTime * movementComponent.moveSpeed;

                    localTransform.Position = localTransform.Position + nextPosition;
                    entityManager.SetComponentData<LocalTransform>(entity, localTransform);

                    if(movementComponent.moveSpeed > 0)
                    {
                        movementComponent.moveSpeed -= 2* SystemAPI.Time.DeltaTime;
                    }
                    else
                    {
                        movementComponent.moveSpeed = 0;
                    }

                    entityManager.SetComponentData<MovementComponent>(entity, movementComponent);
                }
            }*/
        }
    }
}
