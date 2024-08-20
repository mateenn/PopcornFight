using UnityEngine;

namespace ECS.TheSyedMateen.Popcorn
{
    public class CameraHandler : MonoBehaviour
    {
        public static CameraHandler Instance;
        private Camera _camera;
        [SerializeField] private float depthInZ;
        private void Awake()
        {
            Instance = this;
            _camera = Camera.main;
        }

        public Vector3 MousePosition(Vector2 mousePos)
        {
            Debug.Log("I am Called"+_camera);
            return _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depthInZ));

        }

    }
}
