using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GateScript gateScript;
    private bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            Debug.Log("open");
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
