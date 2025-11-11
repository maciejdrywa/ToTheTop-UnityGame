using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0.1f, 20f)] [SerializeField] private float moveSpeed = 0.1f;
    [Range(0.1f, 20f)][SerializeField] private float jumpForce = 0.1f;

    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private LayerMask groundLayer;

    private float rayLength = 0.25f;

    private bool isRunning = false;

    private bool isFacingRight = true;

    private Vector3 theScale;

    private Vector2 startPosition;

    private GameState gameState; 


    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameManager.instance.currentGameState;
    
    }

    // Update is called once per frame
    void Update()
    {
        gameState = GameManager.instance.currentGameState;

        if(gameState == GameState.GAME)
        {
            HandleMovement();

        }


        animator.SetBool("isGrounded", IsGrounded());
        animator.SetBool("isRunning", isRunning);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
            isRunning = true;
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
            isRunning = true;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer.value);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelExit"))
        {
            if (GameManager.instance.keysComplited)
            {
                Debug.Log("End Level");
            } else
            {
                Debug.Log("Nie masz wystarczaj¹cej liczby kluczy");
            }
            
        }

        if (collision.gameObject.CompareTag("LevelFall"))
        {
            Debug.Log("Player fall");
            transform.position = startPosition;
            GameManager.instance.addLives(-1);
            Debug.Log("Stracono 1 ¿ycie");
        }

        if (collision.gameObject.CompareTag("Bonus"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.AddPoints(10);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (transform.position.y > collision.transform.position.y)
            {
                Debug.Log("Killed an enemy");
            }else
            {
                transform.position = startPosition;
                GameManager.instance.addLives(-1);
                Debug.Log("Stracono 1 ¿ycie");
            }
        }


        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.addKeys(collision.gameObject.GetComponent<SpriteRenderer>().color);
            Debug.Log("Zebrano klucz");
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.addLives(1);
            Debug.Log("Dodano 1 ¿ycie");
        }
    }


}
