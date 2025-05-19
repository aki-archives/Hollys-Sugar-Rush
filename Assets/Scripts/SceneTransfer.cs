using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public string targetSceneName;
    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Alpha2)) // Listens for the '2' key press
        {
            LoadTargetScene();
        }
        
    }
    void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty("Level2"))
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }

}
}