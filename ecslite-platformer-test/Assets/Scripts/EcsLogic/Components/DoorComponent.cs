using System;
using System.Numerics;

namespace EcsLogic.Components
{
    public struct DoorComponent
    {
        public Vector3 CurrentPosition;
        public Vector3 DestinationPosition;
        
#if UNITY_EDITOR
        public Action<Vector3> MoveCallback;
#endif
    }
}