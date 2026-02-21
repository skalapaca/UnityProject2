using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private AudioSource audioSource;
    private GameManagerScript gameManagerScript;
    public bool isCollected = false;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManagerScript = FindFirstObjectByType<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; 
            audioSource.Play();
            // turn off components of pickup
            GetComponent<Collider>().enabled = false;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
            // notify game manager
            gameManagerScript.PickupCollected();
            // destroy object after sound finishes
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}