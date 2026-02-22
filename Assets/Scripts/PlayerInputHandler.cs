using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public CreatureScript player;
    public FirstPersonCamera playerCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            // fowards
            direction.z += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            // backwards
            direction.z -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            // left
            direction.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            // right
            direction.x += 1;
        }
        // move player in direction they're facing
        direction = playerCamera.cameraTransform.TransformDirection(direction);
        direction.y = 0;
        player.Move(direction);
        // camera control
        playerCamera.AdjustRotation(Mouse.current.delta.x.value, Mouse.current.delta.y.value);
        player.RotateCreatureForCamera(playerCamera.cameraTransform);
    }
}