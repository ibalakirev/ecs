using Leopotam.Ecs;
using UnityEngine;

public class PlayerMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<MovableComponent, InputEventComponent> _filter;

    public void Run()
    {
        foreach (var entity in _filter)
        {
            ref var inputComponent = ref _filter.Get2(entity);

            ref var movableComponent = ref _filter.Get1(entity);
            movableComponent.transform.position = inputComponent.direction * (Time.deltaTime * movableComponent.moveSpeed);
            movableComponent.transform.forward = inputComponent.direction;
            movableComponent.isMoving = inputComponent.direction.sqrMagnitude > 0;
        }
    }
}
