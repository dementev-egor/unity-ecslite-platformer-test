using System;
using Utils;
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
        [Header("Buttons and doors"), SerializeField]
        private ButtonDoorPair[] buttonDoorPairs;
        [SerializeField, Range(.1f, 3)]
        private float buttonsRadius = 1;
        [SerializeField, Range(.01f, 1)]
        private float doorsOpenSpeed;
        [Header("Other"), SerializeField]
        private ClicksHandler clicksHandler;
        
        private EcsLogic.GameController _gameController;
        private SharedData _sharedData;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            foreach (var pair in buttonDoorPairs)
            {
                Gizmos.DrawWireSphere(pair.Button.position, buttonsRadius);
            }
        }
#endif
        
        private void Awake()
        {
            var playerPosition = player.transform.position;
            var pairs = new EcsLogic.ButtonDoorPair[buttonDoorPairs.Length];

            for (int i = 0; i < pairs.Length; i++)
            {
                var p = buttonDoorPairs[i];
                
                pairs[i] = new EcsLogic.ButtonDoorPair
                {
                    ButtonPosition = p.Button.position.ToSystemV3(),
                    DoorPosition = p.Door.transform.position.ToSystemV3(),
                    DoorMoveCallback = p.Door.SetPosition,
                };
            }

            _gameController = new EcsLogic.GameController();
            _sharedData = new SharedData
            {
                DestinationPlayerPosition = playerPosition.ToSystemV3(),
                PlayerSpeed = playerSpeed,
                PlayerMoveCallback = player.SetPosition,
                
                ButtonDoorPairs = pairs,
                ButtonsRadius = buttonsRadius,
                DoorsOpenSpeed = doorsOpenSpeed,
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