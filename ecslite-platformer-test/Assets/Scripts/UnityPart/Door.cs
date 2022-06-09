using UnityEngine;
using Utils;

namespace UnityPart
{
    public class Door : MonoBehaviour
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