using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;

    private int coins = 0;
    private int cakes = 0;

    [SerializeField] private Image[] coinDigits;
    [SerializeField] private Image[] cakeDigits;
    [SerializeField] private Sprite[] numberSprites; // Assign number sprites (0-9) in the Inspector

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Reset values when the scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetCollectibles(); // Reset on game start
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetCollectibles(); // Reset after each scene transition
    }

    private void ResetCollectibles()
    {
        coins = 0;
        cakes = 0;
        UpdateDisplay(coinDigits, coins);
        UpdateDisplay(cakeDigits, cakes);
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
        UpdateDisplay(coinDigits, coins);
    }

    public void ChangeCakes(int amount)
    {
        cakes += amount;
        UpdateDisplay(cakeDigits, cakes);
    }

    public int GetCakes()
    {
        return cakes;
    }

    private void UpdateDisplay(Image[] digitImages, int value)
    {
        string valueStr = value.ToString().PadLeft(3, '0'); // Always show 3 digits (e.g., 005)
        for (int i = 0; i < digitImages.Length; i++)
        {
            int digit = int.Parse(valueStr[i].ToString());
            digitImages[i].sprite = numberSprites[digit];
        }
    }
}
