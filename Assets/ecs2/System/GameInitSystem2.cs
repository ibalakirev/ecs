using Leopotam.Ecs;
using UnityEngine;

public class GameInitSystem2 : IEcsInitSystem
{
    private readonly EcsWorld _world;

    private readonly UnitInitData2 _cube;
    private readonly UnitInitData2 _sphere;
    private readonly Transform _spawnPointCube;
    private readonly Transform _spawnPointSphere;

    public GameInitSystem2(UnitInitData2 cube, UnitInitData2 shpere, Transform spawnPoint, Transform spawnPointSphere)
    {
        _cube = cube;
        _sphere = shpere;
        _spawnPointCube = spawnPoint;
        _spawnPointSphere = spawnPointSphere;
    }

    public void Init()
    {
        var unitActor = Object.Instantiate(_cube.UnitPrefab, _spawnPointCube.position, Quaternion.identity);

        var cube = _world.NewEntity();

        cube.Get<MessageComponent>();

        var unitActorSphere = Object.Instantiate(_sphere.UnitPrefab, _spawnPointSphere.position, Quaternion.identity);

        var shpere = _world.NewEntity();

        ref var movableComponent = ref shpere.Get<ScalerComponent>();

        movableComponent.transform = unitActorSphere.transform;
    }
}
