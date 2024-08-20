using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ECS.TheSyedMateen.Popcorn
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInputSystem : SystemBase
    {
        private Entity _playerEntity;
        private InputStream _inputStream;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerTag>();
            RequireForUpdate<PlayerTargetPosition>();

            _inputStream = new InputStream();
        }

        protected override void OnStartRunning()
        {
            _inputStream.Enable();
            _inputStream.MouseInput.MousePressed.performed += OnPlayerClickedMouse;
            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnStopRunning()
        {
            _inputStream.MouseInput.MousePressed.performed -= OnPlayerClickedMouse;
            _inputStream.Disable();
        }

        private void OnPlayerClickedMouse(InputAction.CallbackContext obj)
        {
            if (!SystemAPI.Exists(_playerEntity)) return;


            // Get the mouse position and convert it to world coordinates
            Vector2 mousePosition = _inputStream.MouseInput.MouseClink.ReadValue<Vector2>();

            Vector3 worldPosition = CameraHandler.Instance.MousePosition(mousePosition);

            // Set the player target position
            SystemAPI.SetSingleton(new PlayerTargetPosition { value = new float3(worldPosition.x, worldPosition.y, 0) });

        }
    }
}
