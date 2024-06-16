using UnityEngine;
using Leopotam.Ecs;

public class PlayerInputSystem : IEcsRunSystem
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private readonly EcsFilter<InputEventComponent> _filter;

    public void Run()
    {
        var horizontal = Input.GetAxis(HorizontalAxis);
        var vertical = Input.GetAxis(VerticalAxis);

        foreach(var enity in  _filter)
        {
            ref var inputEvent = ref _filter.Get1(enity);
            inputEvent.direction = new Vector3(horizontal, 0, vertical);
        }
    }
}
