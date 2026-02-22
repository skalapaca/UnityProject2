using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public PickupScript[] pickups;
    private AudioSource audioSource;
    void Awake()
    {
        pickups = FindObjectsByType<PickupScript>(FindObjectsSortMode.None);
        audioSource = GetComponent<AudioSource>();
    }

    public void PickupCollected()
    {
        bool allPickedUp = true;
        // check to see if each pickup has been picked up
        foreach(var pickup in pickups)
        {
            if (!pickup.isCollected)
            {
                allPickedUp = false;
                break;
            }
        }
        if (allPickedUp)
        {
            // play win sound and wait for three seconds to reset scene
            audioSource.Play();
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        // wait for three seconds to reset level
        yield return new WaitForSeconds(3);
        ResetLevel();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}