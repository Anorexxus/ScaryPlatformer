using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GateScript gateScript;
    private bool push = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (push == true)
        {
            gateScript.OpenGate();
        }
     
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
        push = true;
        }
    }
 
}
