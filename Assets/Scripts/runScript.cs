using UnityEngine;

public class runScript : MonoBehaviour
{
    private EnemyDarkScript EnemyDark;
    [SerializeField]private PlayerController Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Flash"))
        {
        EnemyDark = GetComponentInParent<EnemyDarkScript>();
        EnemyDark.target = other.gameObject;
        EnemyDark.see = false;
        
        }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
         Player.takeDamage();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
       EnemyDark.see = null;
       Debug.Log("Left");
        }
    }
}
