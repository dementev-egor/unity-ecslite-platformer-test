using System;
using System.Numerics;

namespace EcsLogic
{
    public class SharedData
    {
#if UNITY_EDITOR
        public Action<Vector3> PlayerMoveCallback;
#endif
        public Vector3 DestinationPlayerPosition;
        public float PlayerSpeed;

        public Vector3[] ButtonsPosition;
    }
}