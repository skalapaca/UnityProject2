using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerScript player;
    void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
        player.Move(direction);
    }
}
