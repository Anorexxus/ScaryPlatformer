using UnityEngine;

public class EnemyScript : MonoBehaviour
{
      private float speed = 3f;
    private bool turnRight;
    private bool shouldMove = false;
    private bool flipSprite;
    public GameObject player;
    public GameObject flashLight;

    [SerializeField]private SpriteRenderer spriteRenderer;
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
        
        if (collision.CompareTag("Flash"))
        {
        Vector3 detectedPosition = flashLight.transform.position;
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
