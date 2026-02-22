using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CreatureScript : MonoBehaviour
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

    public void RotateCreatureForCamera(Transform cameraTransform)
    {
        transform.rotation = cameraTransform.rotation;
    }

    private void SimulateGravity()
    {
        if (cc.isGrounded)
        {
            gravityTracker = -2f;
        }
        else
        {
            gravityTracker += gravity * Time.deltaTime;
        }
        cc.Move(new Vector3(0,gravityTracker,0) * Time.deltaTime);
    }
}