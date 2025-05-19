using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private bool isCoin = true;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            if (isCoin)
            {
                CollectibleManager.instance.ChangeCoins(1);
            }
            else
            {
                CollectibleManager.instance.ChangeCakes(value);
            }

            Destroy(gameObject);
        }
    }
}

