using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine; // Import Cinemachine

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject player; 

    void Awake()
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject);
            return;
        } 
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "StartMenu")
        {
            Destroy(gameObject); // Destroy the singleton when in the Start Menu
            return;
        }

        // Find the Player again after the new scene loads
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            AssignCameraToPlayer();
        }
        else
        {
            Debug.LogError("Player not found after scene load!");
        }
    }

    private void AssignCameraToPlayer()
    {
        CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
        if (cam != null && player != null)
        {
            cam.Follow = player.transform;
            Debug.Log("Camera now following Player.");
        }
        else
        {
            Debug.LogError("Camera not found or Player is missing!");
        }
    }
}
