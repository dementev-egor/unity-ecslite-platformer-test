using System.Numerics;

namespace EcsLogic
{
    public class SharedData
    {
#if UNITY_EDITOR
        public UnityEngine.Transform PlayerTransform;
#endif
        public Vector3 DestinationPlayerPosition;
        public float PlayerSpeed;
    }
}