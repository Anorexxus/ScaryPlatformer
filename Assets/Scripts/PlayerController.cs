using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;
    private bool canJump = false;
    private bool isFacingRight;
    public float health = 10f;
    private SpriteRenderer spriteRenderer;

    public GameObject flashLight;

    private float timer;
    private float timeDuration = 5f;

    public Light2D lightFlash;
    public PolygonCollider2D polyCollFlash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();

        polyCollFlash.enabled = false;
    }
    
    public void takeDamage()
    {
        
        if (timer <= timeDuration)
        {
            Debug.Log("ouch");
    health -= 2.0f;
    timer = 0f;
        }
    if (health <= 0)
    die();
    }
    // Update is called once per frame

    

    void Update()
    {// Move the player left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = (mousePosition - flashLight.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        flashLight.transform.rotation = Quaternion.Euler(0,0, angle - 90);

        if (horizontalInput == 1)
        {
        isFacingRight = true;
        }
        else if (horizontalInput == -1) 
        {
            isFacingRight = false;
        }
        Flip();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        lightFlash.intensity = 1f;
        polyCollFlash.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
        lightFlash.intensity = 0f;
        polyCollFlash.enabled = false;
        }

    
       timer += Time.deltaTime;
       
       
    

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
    
