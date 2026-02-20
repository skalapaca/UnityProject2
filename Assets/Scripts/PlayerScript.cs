using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    CharacterController cc;
    [Header("Player Stats")]
    public float speed = 10f;

    [Header("Gravity")]
    private float gravity = -9.81f;
    private float gravityTracker = 0f;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SimulateGravity();
    }

    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            return;
        }
        direction = direction.normalized;
        cc.Move(speed * Time.deltaTime * direction);
    }

    private void SimulateGravity()
    {
        if (cc.isGrounded)
        {
            gravityTracker = -1f;
        }
        else
        {
            gravityTracker += gravity * Time.deltaTime;
        }
        cc.Move(new Vector3(0,gravityTracker,0) * Time.deltaTime);
    }
}