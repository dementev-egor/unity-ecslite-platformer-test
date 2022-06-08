using Leopotam.EcsLite;

namespace EcsLogic
{
    public class GameController
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        public void Initialize()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
        }

        public void Run()
        {
            _systems?.Run();
        }

        public void Destroy()
        {
            _systems?.Destroy();
            _systems = null;
            
            _world?.Destroy();
            _world = null;
        }
    }
}