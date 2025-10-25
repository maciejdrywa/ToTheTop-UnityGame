using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0.1f, 20f)] [SerializeField] private float moveSpeed = 0.1f;
    [Range(0.1f, 20f)][SerializeField] private float jumpForce = 0.1f;
    [Space(10)]

    private Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;

    private float rayLength = 0.25f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red, 0.2f, false);
    }

    void jump()
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
            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("LevelFall"))
        {
            Debug.Log("Player fall");
        }
    }


}
