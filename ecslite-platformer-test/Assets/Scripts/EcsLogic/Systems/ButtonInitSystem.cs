using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class ButtonInitSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;

        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();
            var pool = _world.GetPool<ButtonPositionComponent>();
            var sharedData = systems.GetShared<SharedData>();

            foreach (var position in sharedData.ButtonsPosition)
            {
                var entity = _world.NewEntity();

                ref var pos = ref pool.Add(entity);
                pos.Position = position;
            }
        }

        public void Destroy(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<ButtonPositionComponent>().End();

            foreach (var entity in filter)
                _world?.DelEntity(entity);
            
            _world = null;
        }
    }
}