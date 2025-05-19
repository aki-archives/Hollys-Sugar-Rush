using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject creditsPanel; // Assign this in the inspector
    public GameObject sceneSelectorPanel; // Assign this in the inspector

    public void OnStartClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnExitClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void OnCreditsClick()
    {
        creditsPanel.SetActive(true); // Show credits panel
    }

    public void OnCloseCredits()
    {
        creditsPanel.SetActive(false); // Hide credits panel
    }

    public void OnSceneSelectorClick()
    {
        sceneSelectorPanel.SetActive(true); // Show scene selector
    }

    public void OnCloseSceneSelector()
    {
        sceneSelectorPanel.SetActive(false); // Hide scene selector
    }
}
