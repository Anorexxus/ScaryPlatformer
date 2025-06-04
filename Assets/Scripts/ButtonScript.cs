using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GateScript gateScript;
    private bool push = false;
    
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
