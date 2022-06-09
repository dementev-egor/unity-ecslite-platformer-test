using System;
using System.Numerics;

namespace EcsLogic
{
    public class SharedData
    {
        public Vector3 DestinationPlayerPosition;
        public float PlayerSpeed;
#if UNITY_EDITOR
        public Action<Vector3> PlayerMoveCallback;
#endif

        public ButtonDoorPair[] ButtonDoorPairs;
        public float ButtonsRadius;
        public float DoorsOpenSpeed;
    }

    public class ButtonDoorPair
    {
        public Vector3 ButtonPosition;
        public Vector3 DoorPosition;
#if UNITY_EDITOR
        public Action<Vector3> DoorMoveCallback;
#endif
    }
}