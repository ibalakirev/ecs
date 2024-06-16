using Leopotam.Ecs;
using UnityEngine;


public class ScalerSystem : IEcsRunSystem
{
    private readonly EcsFilter<ScalerComponent> _filterScale;
    private Vector3 _scale = Vector3.one;

    public void Run()
    {
        foreach (var entity in _filterScale)
        {
            ref var scalerComponent = ref _filterScale.Get1(entity);

            scalerComponent.transform.localScale += _scale * 1f;

            Debug.Log("Óðà");
        }
    }
}
