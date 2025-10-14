using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    [Range(0.1f, 20f)] [SerializeField] private float moveSpeed = 0.1f;



    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
    }
}
