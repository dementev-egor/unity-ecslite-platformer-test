using System.Numerics;
using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private SharedData _sharedData;

        public void Init(EcsSystems systems)
        {
            _sharedData = systems.GetShared<SharedData>();
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<PlayerPositionComponent>();
            var filter = world.Filter<PlayerPositionComponent>().End();

            foreach (var entity in filter)
            {
                ref var pos = ref pool.Get(entity);

                var destination = _sharedData.DestinationPlayerPosition - pos.Position;
            
                if (destination.Length() < .1f)
                    return;

                var delta = Vector3.Normalize(destination) * _sharedData.PlayerSpeed;
                pos.Position += delta;

#if UNITY_EDITOR
                _sharedData.PlayerMoveCallback?.Invoke(pos.Position);
#endif
            }
        }
    }
}