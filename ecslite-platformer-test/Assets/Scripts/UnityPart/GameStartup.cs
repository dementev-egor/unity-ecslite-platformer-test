using System;
using EcsLogic;
using UnityEngine;

namespace UnityPart
{
    public class GameStartup : MonoBehaviour
    {
        private GameController _gameController;

        private void Awake()
        {
            _gameController = new GameController();
            _gameController.Initialize();
        }

        private void Update()
        {
            _gameController.Run();
        }

        private void OnDestroy()
        {
            _gameController.Destroy();
        }
    }
}