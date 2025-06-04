using System.Collections;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Light2D lightFlash;
    public PolygonCollider2D polyCollFlash;
    public Slider staminaBar;
    [SerializeField]
    private DeathScript DeathScript;

    public bool canJump = false;
    public bool resting = false;
    private bool isFacingRight;

    public float speed = 3.0f;
    public float health = 10f;
    public float sprintTimer = 0f;
    public float sprintTimerMax = 5f;

    public GameObject flashLight;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float timer;
    private float timeDuration = 5f;
    private float jumpForce = 7.0f;
    Vector2 movement;
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
            DeathScript.Die();
    }

    void Update()
    {// Move the player left and right
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movement.normalized.x * speed, rb.linearVelocity.y);
        Flip();
        if (resting == true && !Input.GetKey(KeyCode.LeftControl))
        {
            resting = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer < sprintTimerMax)
        {
            speed = 6f;
            sprintTimer += 1 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || sprintTimer > sprintTimerMax)
        {
            speed = 3f;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(Rest(1.0f));
        }
        if (sprintTimer < 0)
        {
            sprintTimer = 0;
        }
        if (sprintTimer > 5)
        {
            sprintTimer = 5;
        }
        if (resting == true)
        {
            sprintTimer -= 0.5f * Time.deltaTime;
        }
        staminaBar.SetValueWithoutNotify(sprintTimer);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (DeathScript.isPaused == false)
        {
        Vector3 direction = (mousePosition - flashLight.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        flashLight.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        if (movement.x < 0)
        {
            isFacingRight = true;
        }
        if (movement.x > 0)
        {
            isFacingRight = false;
        }
        if (DeathScript.isPaused == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            lightFlash.intensity = 1f;
            polyCollFlash.enabled = true;
        }
        else if (DeathScript.isPaused == false && Input.GetKeyUp(KeyCode.Mouse0))
        {
            lightFlash.intensity = 0f;
            polyCollFlash.enabled = false;
        }


        timer += Time.deltaTime;


        if (canJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.75f);
            speed = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.6f);
            speed = 3;
        }

    }

    IEnumerator Rest(float delay)
    {
        yield return new WaitForSeconds(delay);
        resting = true;
    }


    private void Flip()
    {
        if (isFacingRight == true)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}