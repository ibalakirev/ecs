using UnityEngine;
using Leopotam.Ecs;


public class MessageSystem : IEcsRunSystem
{
    private readonly EcsFilter<MessageComponent> _filter;
    private string _message;

    public void Run()
    {
        foreach(var entity in _filter)
        {
            ref var messageComponent = ref _filter.Get1(entity);

            messageComponent.message = "ага";

            _message = messageComponent.message;

            Debug.Log(_message);
        }
    }
}
