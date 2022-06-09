using System.Numerics;
using EcsLogic.Components;
using Leopotam.EcsLite;

namespace EcsLogic.Systems
{
    public class PlayerOnButtonSystem : IEcsInitSystem, IEcsRunSystem
    {
        private SharedData _sharedData;
        
        public void Init(EcsSystems systems)
        {
            _sharedData = systems.GetShared<SharedData>();
        }
        
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerPool = world.GetPool<PlayerPositionComponent>();
            var playerFilter = world.Filter<PlayerPositionComponent>().End();
            
            var player = playerFilter.GetRawEntities()[0];
            ref var playerPos = ref playerPool.Get(player);

            var buttonsPool = world.GetPool<ButtonComponent>();
            var buttonsFilter = world.Filter<ButtonComponent>().End();

            foreach (var buttonEntity in buttonsFilter)
            {
                ref var button = ref buttonsPool.Get(buttonEntity);
                var dist = (playerPos.CurrentPosition - button.Position).Length();

                if (dist < _sharedData.ButtonsRadius)
                {
                    MoveDoor(world, button.ConnectedDoor);
                }
            }
        }

        private void MoveDoor(EcsWorld world, int doorEntity)
        {
            var pool = world.GetPool<DoorComponent>();
            ref var door = ref pool.Get(doorEntity);

            var dir = door.DestinationPosition - door.CurrentPosition;
            var diff = dir.Length();

            if (diff < .1f)
                return;

            var delta = Vector3.Normalize(dir) * _sharedData.DoorsOpenSpeed;
            door.CurrentPosition += delta;

#if UNITY_EDITOR
            door.MoveCallback?.Invoke(door.CurrentPosition);
#endif
        }
    }
}