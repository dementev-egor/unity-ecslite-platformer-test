using UnityEngine;

namespace UnityPart
{
    public class ClicksHandler : MonoBehaviour
    {
        public delegate void OnMouseClickedDelegate(Vector3 worldPosition);

        public event OnMouseClickedDelegate OnMouseClicked;
        
        [SerializeField]
        private Camera camera;

        private RaycastHit[] _hits = new RaycastHit[3];
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnMouseClick();
        }

        private void OnMouseClick()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            var hitsCount = Physics.RaycastNonAlloc(ray, _hits, camera.farClipPlane);
            
            if (hitsCount == 0)
                return;

            Vector3? hitPoint = null;
            
            for (int i = 0; i < _hits.Length; i++)
            {
                if (hitPoint == null)
                {
                    var floor = _hits[i].collider.GetComponent<Floor>();

                    if (floor != null)
                        hitPoint = _hits[i].point;
                }

                _hits[i] = default;
            }
            
            if (hitPoint == null)
                return;

            OnMouseClicked?.Invoke(hitPoint.Value);
        }
    }
}