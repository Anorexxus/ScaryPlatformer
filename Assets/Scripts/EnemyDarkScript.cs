using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDarkScript : MonoBehaviour
{
    private float PosX;
    private float PosY;
    public bool? see;
    
    public float speed;
    
    public CircleCollider2D detector;
    public GameObject target;
    public CircleCollider2D runDetector;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        see = null;
  
       
    }

    // Update is called once per frame
    void Update()
    {
        if (see == true)
         Follow();

        if (see == false)
       runAway();

       
        
        
    }
    void Follow()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    void runAway()
    {
        Vector3 runDirrection = transform.position - target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position,transform.position +runDirrection , speed *Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag("Player"))
        { 
        target = collision.gameObject;
        see = true;
        }
        
       
        
        
    
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
       see = null;
    }
    
}
