using System.Numerics;
using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private SharedData _sharedData;
        private int _player;
        private EcsPool<PlayerPositionComponent> _pool;

        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();
            _sharedData = systems.GetShared<SharedData>();
            _pool = _world.GetPool<PlayerPositionComponent>();
            _player = _world.NewEntity();
            _pool.Add(_player);
        }

        public void Run(EcsSystems systems)
        {
            ref var pos = ref _pool.Get(_player);

            var destination = _sharedData.DestinationPlayerPosition - pos.Position;
            
            if (destination.Length() < .1f)
                return;

            var delta = Vector3.Normalize(destination) * _sharedData.PlayerSpeed;
            pos.Position += delta;

#if UNITY_EDITOR
            var playerTransformPosition = _sharedData.PlayerTransform.position;
            playerTransformPosition.x = pos.Position.X;
            playerTransformPosition.y = pos.Position.Y;
            playerTransformPosition.z = pos.Position.Z;
            _sharedData.PlayerTransform.position = playerTransformPosition;
#endif
        }

        public void Destroy(EcsSystems systems)
        {
            _world.DelEntity(_player);
            _world = null;
        }
    }
}