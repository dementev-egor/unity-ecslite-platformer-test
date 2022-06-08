using UnityEngine;

namespace UnityPart
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform cameraTransform;
        [SerializeField]
        private Vector3 offset;
        [SerializeField]
        private Transform followTarget;

        private void Update()
        {
            if (cameraTransform == null || followTarget == null)
                return;

            cameraTransform.position = followTarget.position + offset;
        }
    }
}