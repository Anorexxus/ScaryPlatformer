using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;
    private bool canJump = false;
    private bool isFacingRight;
    public float health = 10f;
    private SpriteRenderer spriteRenderer;

    private float timer;
    private float timeDuration = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void takeDamage()
    {
        Debug.Log("ouch");
        if (timer <= timeDuration)
    health -= 2.0f;
    timer = 0f;
    if (health <= 0)
    die();
    }
    // Update is called once per frame

    

    void Update()
    {// Move the player left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    {
        if (horizontalInput == 1)
        {
        isFacingRight = true;
        }
        else if (horizontalInput == -1) 
        {
            isFacingRight = false;
        }
        Flip();
    }
       timer += Time.deltaTime;
       if (timer == 0)
       Debug.Log("timerOff");
       

        // Make the player jump
        if (canJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.5f , 0.75f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f , 1.6f);
        }
        
    
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
           canJump = true; 
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
    private void Flip()
    {
        if (isFacingRight)
        {
        spriteRenderer.flipX = true;
        }
        else
        {
        spriteRenderer.flipX = false; 
        }
    }
public void die()
        {
        Destroy(gameObject);
        }
}
    
