using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController cc;

    public float speed = 10f;

    void Awake()
    {
        Debug.Log("Player script awake");
        cc = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            Debug.Log("vector = 0");
            return;
        }
        Debug.Log("direction moving");
        direction = direction.normalized;
        cc.Move(direction * speed * Time.deltaTime);
    }
}
