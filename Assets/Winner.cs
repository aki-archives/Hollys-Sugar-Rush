using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    [SerializeField] private GameObject winUI; // Assign in Inspector
    public static Winner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (winUI != null)
        {
            winUI.SetActive(false); // Ensure the win screen is hidden at start
        }
    }

    public void ShowWinScreen()
    {
        if (winUI != null)
        {
            winUI.SetActive(true); // Display Win UI
            Time.timeScale = 0f; // Pause game
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Unpause game
        SceneManager.LoadScene("StartMenu"); // Load main menu scene
    }
}