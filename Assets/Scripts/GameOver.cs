using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        // Reset Player Health
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)

        {   Debug.Log("Player found! Resetting health...");
            player.ResetHealth();  // Reset deaths & respawn position
        }

        gameObject.SetActive(false);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
