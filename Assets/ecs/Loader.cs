using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ecs.System
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private UnitInitData _playerData;
        [SerializeField] private UnitInitData _enemyData;
        [SerializeField] private Transform _spawnPoint;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.Add(new GameInitSystem(_playerData, _enemyData, _spawnPoint));
            _systems.Add(new PlayerInputSystem());
            _systems.Add(new PlayerMoveSystem());  

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
}


