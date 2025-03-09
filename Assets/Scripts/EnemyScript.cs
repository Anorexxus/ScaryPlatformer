using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 3f;
    private bool turnRight;
    private bool shouldMove = false;
    private bool flipSprite;
    public GameObject player;

    [SerializeField]private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (shouldMove)
    {
       if (turnRight)
       transform.Translate(Vector3.right * speed * Time.deltaTime);
       else
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        Vector3 detectedPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        
        if (detectedPosition.x > enemyPosition.x)
        {
            turnRight = true;
            FlipRight();
        }
        else
        {
           turnRight = false;
           FlipLeft();
        }
        shouldMove = true;
        }
        if (collision.CompareTag("Damage")) 
        {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController !=null)
        {
            playerController.takeDamage();
        }
        else
        {
            Debug.LogError("PlayerController component not found on the player GameObject.");
        }
        }
    }
    private void FlipLeft()
    {
    spriteRenderer.flipX = true;
    }
    private void FlipRight()
    {
    spriteRenderer.flipX = false;
    }
}
