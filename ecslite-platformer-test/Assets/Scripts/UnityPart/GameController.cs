using DefaultNamespace;
using EcsLogic;
using UnityEngine;

namespace UnityPart
{
    public class GameController : MonoBehaviour
    {
        [Header("Player"), SerializeField]
        private Player player;
        [SerializeField, Range(.01f, 1)]
        private float playerSpeed;
        [Header("Buttons"), SerializeField]
        private Transform[] buttons;
        [Header("Other"), SerializeField]
        private ClicksHandler clicksHandler;
        
        private EcsLogic.GameController _gameController;
        private SharedData _sharedData;

        private void Awake()
        {
            var playerPosition = player.transform.position;
            var buttonsPositions = new System.Numerics.Vector3[buttons.Length];

            for (int i = 0; i < buttonsPositions.Length; i++)
                buttonsPositions[i] = buttons[i].position.ToSystemV3();

            _gameController = new EcsLogic.GameController();
            _sharedData = new SharedData
            {
                PlayerMoveCallback = player.SetPosition,
                DestinationPlayerPosition = playerPosition.ToSystemV3(),
                PlayerSpeed = playerSpeed,
                
                ButtonsPosition = buttonsPositions,
            };
            
            _gameController.Initialize(_sharedData);
            
            clicksHandler.OnMouseClicked += OnMouseClicked;
        }

        private void OnMouseClicked(Vector3 worldPosition)
        {
            _sharedData.DestinationPlayerPosition.X = worldPosition.x;
            _sharedData.DestinationPlayerPosition.Y = worldPosition.y;
            _sharedData.DestinationPlayerPosition.Z = worldPosition.z;
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