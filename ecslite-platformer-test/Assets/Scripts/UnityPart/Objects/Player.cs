using Utils;
using UnityEngine;

namespace UnityPart.Objects
{
    public class Player : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetPosition(System.Numerics.Vector3 pos)
        {
            _transform.position = pos.ToUnityV3();
        }
    }
}