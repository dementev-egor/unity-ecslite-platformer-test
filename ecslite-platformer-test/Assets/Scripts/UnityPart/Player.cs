using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace UnityPart
{
    public class Player : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetPosition(Vector3 pos)
        {
            var position = _transform.position;

            position.x = pos.X;
            position.y = pos.Y;
            position.z = pos.Z;

            _transform.position = position;
        }
    }
}