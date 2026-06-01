using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float gravity = -9.8f;
    private Vector3 direction;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); 
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update() {
        bool jumpkey = false;
if(Keyboard.current != null)
        {
           jumpkey = Keyboard.current.spaceKey.wasPressedThisFrame|| 
           Keyboard.current.wKey.wasPressedThisFrame|| 
           Keyboard.current.upArrowKey.wasPressedThisFrame;
        }
        if(jumpkey)
        {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
           FindAnyObjectByType<gameManager>().Gameover();
        }
        else if(collision.gameObject.CompareTag("Scoring"))
        {
            FindAnyObjectByType<gameManager>().ScoreIncrease();
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            FindAnyObjectByType<gameManager>().IncreaseDiamond();
            Destroy(collision.gameObject);
        }
    }
    
}
