using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction = direction.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        direction *= speed;
        direction *= Time.deltaTime;
        transform.position += direction;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}