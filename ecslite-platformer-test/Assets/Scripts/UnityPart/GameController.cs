using EcsLogic;
using UnityEngine;

namespace UnityPart
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;
        [SerializeField, Range(.01f, 1)]
        private float playerSpeed;
        [SerializeField]
        private ClicksHandler clicksHandler;
        
        private EcsLogic.GameController _gameController;
        private SharedData _sharedData;

        private void Awake()
        {
            _gameController = new EcsLogic.GameController();
            var playerPosition = playerTransform.position;
            _sharedData = new SharedData
            {
                PlayerTransform = playerTransform,
                DestinationPlayerPosition = new System.Numerics.Vector3(
                    playerPosition.x,
                    playerPosition.y,
                    playerPosition.z),
                PlayerSpeed = playerSpeed,
            };
            
            _gameController.Initialize(_sharedData);
            
            clicksHandler.OnMouseClicked += OnMouseClicked;
        }

        private void OnMouseClicked(float x, float y, float z)
        {
            _sharedData.DestinationPlayerPosition.X = x;
            _sharedData.DestinationPlayerPosition.Y = y;
            _sharedData.DestinationPlayerPosition.Z = z;
        }

        private void Update()
        {
            _sharedData.PlayerSpeed = playerSpeed;
            _gameController.Run();
        }

        private void OnDestroy()
        {
            _gameController.Destroy();
        }
    }
}