using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{
    private bool playerNearby;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite closedDoor; // Closed door sprite
    [SerializeField] private Sprite openDoor;   // Open door sprite
    [SerializeField] private GameObject winUI;  // Assign in Inspector

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor; // Set closed door as default

        if (winUI != null)
        {
            winUI.SetActive(false); // Hide win UI initially
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (CollectibleManager.instance.GetCakes() >= 3) // Require 3 cakes to enter
            {
                StartCoroutine(OpenDoorAndProceed());
            }
            else
            {
                Debug.Log("You need to collect 3 cakes to enter!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    IEnumerator OpenDoorAndProceed()
    {
        spriteRenderer.sprite = openDoor; // Change to open door sprite
        yield return new WaitForSeconds(1f); // Wait 1 second before transitioning

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level1")
        {
            LoadLevel("Level2"); // Move to Level 2
        }
        else if (currentScene == "Level2")
        {
            LoadLevel("Level3"); // Move to Level 3
        }
        else if (currentScene == "Level3") 
        {
            ShowWinScreen(); // If Level 3, show "You Win" UI instead
        }
    }

    private void LoadLevel(string levelName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Attach scene load event
        SceneManager.LoadScene(levelName); // Load next level
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.Find("SpawnPoint"); // Locate spawn point

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position; // Move player
        }

        SceneManager.sceneLoaded -= OnSceneLoaded; // Remove event listener
    }

    private void ShowWinScreen()
    {
        if (Winner.instance != null)
        {
        Winner.instance.ShowWinScreen(); // Show win UI from WinManager
        }

        }
    }
