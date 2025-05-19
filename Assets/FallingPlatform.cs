using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallWait = 2f;
    public float destroyWait = 1f;

    private bool isFalling = false;
    private Rigidbody2D rb;
    private Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position; // Save the original position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyWait);
        gameObject.SetActive(false); // Disable instead of destroying
    }

    public void ResetPlatform()
    {  
        Debug.Log("Resetting platform: " + gameObject.name);
        isFalling = false;
        transform.position = startPos;
        rb.bodyType = RigidbodyType2D.Kinematic; 
        rb.velocity = Vector2.zero; 
        gameObject.SetActive(true); 
    }
}
