using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class PlayerInitSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private int _player;

        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();
            _player = _world.NewEntity();
            
            var pool = _world.GetPool<PlayerPositionComponent>();
            ref var pos = ref pool.Add(_player);

            var sharedData = systems.GetShared<SharedData>();
            pos.Position = sharedData.DestinationPlayerPosition;
        }

        public void Destroy(EcsSystems systems)
        {
            _world.DelEntity(_player);
            _world = null;
        }
    }
}