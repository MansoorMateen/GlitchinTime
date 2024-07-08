using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float growthFactor = 1.1f;
    public float speedIncrement = 0.5f;
    private AudioSource audioSource;

    private Rigidbody2D rb;

    public List<ItemCounter> itemCounters = new List<ItemCounter>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        UpdateAllItemTexts();
    }

    void Update()
    {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveInput.y += 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveInput.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput.x += 1;
        }

        moveInput.x += Input.GetAxis("Horizontal");
        moveInput.y += Input.GetAxis("Vertical");

        moveInput = moveInput.normalized;
        rb.velocity = moveInput * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var itemCounter in itemCounters)
        {
            if (other.gameObject.CompareTag(itemCounter.itemPrefab.tag)) // Assuming you're using tags for identification
            {
                ItemProperties itemProperties = other.GetComponent<ItemProperties>();
                if (itemProperties != null)
                {
                    Destroy(other.gameObject);
                    transform.localScale *= itemProperties.growthFactor;
                    speed += itemProperties.speedIncrement;

                    // Play the item's specific collection sound
                    if (itemProperties.collectSound != null && audioSource != null)
                    {
                        audioSource.PlayOneShot(itemProperties.collectSound);
                    }

                    itemCounter.count++;
                    UpdateItemText(itemCounter);
                    break; // Exit loop since we found the matching item
                }
            }
        }

        if (other.gameObject.CompareTag("GameOverItem"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateItemText(ItemCounter itemCounter)
    {
        if (itemCounter.countText != null)
        {
            itemCounter.countText.text = itemCounter.itemPrefab.name + ": " + itemCounter.count;
        }
    }

    void UpdateAllItemTexts()
    {
        foreach (var itemCounter in itemCounters)
        {
            UpdateItemText(itemCounter);
        }
    }
}
