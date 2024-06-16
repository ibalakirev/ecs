using Leopotam.Ecs;
using UnityEngine;

public class Loader2 : MonoBehaviour
{
    [SerializeField] private UnitInitData2 _cube;
    [SerializeField] private UnitInitData2 _sphere;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointSphere;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.Add(new GameInitSystem2(_cube, _sphere, _spawnPoint, _spawnPointSphere));
        _systems.Add(new MessageSystem());
        _systems.Add(new ScalerSystem());

        _systems.Init();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _world.Destroy();
    }
}
