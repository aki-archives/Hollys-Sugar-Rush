using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Vector2 startPos;
    SpriteRenderer spriteRenderer;
    private int deathCount = 0; 
    private int maxDeaths = 3; 

    [SerializeField] private GameObject gameOverUI; // Assign this in Inspector
    private PlayerMovement playerController; // Reference to disable movement

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerMovement>(); // Get the player movement script
    }

    private void Start()
    {
        startPos = transform.position;
        gameOverUI.SetActive(false); // Hide Game Over UI at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        deathCount++;

        if (deathCount >= maxDeaths)
        {
            GameOver();
            return;
        }

        StartCoroutine(Respawn(0.5f));
    }


    void ResetPlatforms()
    {
    FallingPlatform[] platforms = FindObjectsOfType<FallingPlatform>(true); // Find even inactive ones
    foreach (FallingPlatform platform in platforms)
    {
        platform.gameObject.SetActive(true); // Ensure activation
        platform.ResetPlatform(); // Call reset method
    }
    }

IEnumerator Respawn(float duration)
{
    spriteRenderer.enabled = false;
    yield return new WaitForSeconds(duration);
    
    transform.position = startPos;
    spriteRenderer.enabled = true;

    ResetPlatforms(); // Ensure all platforms are restored

    Camera.main.transform.position = new Vector3(startPos.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

    ParallaxController[] parallaxObjects = FindObjectsOfType<ParallaxController>();
    foreach (ParallaxController parallax in parallaxObjects)
    {
        parallax.ResetParallax();
    }
}
    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true); // Show Game Over UI
        if (playerController != null)
        {
            playerController.enabled = false; // Disable player movement
        }
    }
    public void ResetHealth()
    {
    Debug.Log("ResetHealth called!");

    deathCount = 0; // Reset death count
    transform.position = startPos; // Reset player position
    GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Stop any movement force

    // Re-enable player movement if it's disabled
    PlayerMovement movement = GetComponent<PlayerMovement>(); 
    if (movement != null)
    {
        movement.enabled = true;
    }

    
    GameObject gameOverUI = GameObject.Find("GameOver");
    if (gameOverUI != null)
    {
        gameOverUI.SetActive(false);
    }
}

}
