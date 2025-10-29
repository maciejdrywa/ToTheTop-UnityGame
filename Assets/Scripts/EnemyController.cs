using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    [Header("Movement Settings")]
    [Range(0.1f, 20f)][SerializeField] private float moveSpeed = 0.1f;

    private Animator animator;

    private bool isFacingRight = false;

    private float startPositionX;
    private float moveRange = 1.0f;

    private bool isMovingRight = false;


    private Vector3 theScale;



    void Awake()
    {
        animator = GetComponent<Animator>();
        startPositionX = transform.position.x;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            if (transform.position.x <= startPositionX + moveRange)
            {
                MoveRight();
            } else
            {
                isMovingRight = false;
                Flip();
            }
        } else
        {
            if (transform.position.x >= startPositionX - moveRange)
            {
                MoveLeft();
            } else
            {
                isMovingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void MoveRight()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
    }

    void MoveLeft()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
    }

    IEnumerator KillOnAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                Debug.Log("Killed an enemy");
                moveSpeed = 0;
                animator.SetBool("isDead", true);
                StartCoroutine(KillOnAnimation());
            }

        }
    }
}
