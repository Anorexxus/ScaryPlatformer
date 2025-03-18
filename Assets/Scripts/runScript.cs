using UnityEngine;

public class runScript : MonoBehaviour
{
    [SerializeField]private EnemyDarkScript Nigger;
    [SerializeField]private PlayerController White;
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
        Nigger.target = other.gameObject;
        Nigger.see = false;
        Debug.Log("Nigger not see");
        }
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
         White.takeDamage();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
       Nigger.see = null;
       Debug.Log("Left");
        }
    }
}
