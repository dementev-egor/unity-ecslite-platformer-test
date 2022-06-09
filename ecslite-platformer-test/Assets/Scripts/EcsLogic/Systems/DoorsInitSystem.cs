using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class ButtonDoorsInitSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        
        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();
            var buttonsPool = _world.GetPool<ButtonComponent>();
            var doorsPool = _world.GetPool<DoorComponent>();
            var sharedData = systems.GetShared<SharedData>();

            foreach (var pair in sharedData.ButtonDoorPairs)
            {
                var doorEntity = _world.NewEntity();

                ref var door = ref doorsPool.Add(doorEntity);
                var destPos = pair.DoorPosition;
                destPos.X = -destPos.X;
                door.CurrentPosition = pair.DoorPosition;
                door.DestinationPosition = destPos;
                
#if UNITY_EDITOR
                door.MoveCallback = pair.DoorMoveCallback;
#endif

                var buttonEntity = _world.NewEntity();
                ref var button = ref buttonsPool.Add(buttonEntity);
                button.Position = pair.ButtonPosition;
                button.ConnectedDoor = doorEntity;
            }
        }

        public void Destroy(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<DoorComponent>().End();

            foreach (var entity in filter)
                _world?.DelEntity(entity);
            
            filter = systems.GetWorld().Filter<ButtonComponent>().End();

            foreach (var entity in filter)
                _world?.DelEntity(entity);
            
            _world = null;
        }
    }
}