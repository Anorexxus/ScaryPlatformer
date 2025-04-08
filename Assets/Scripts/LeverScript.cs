using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GateScript gateScript;
    private bool inRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            gateScript.OpenGate();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
