using UnityEngine;

public class GateScript : MonoBehaviour
{
    
    [SerializeField] bool openGate = false;
    
    private int playerLayer;
    private int gateLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        gateLayer = LayerMask.NameToLayer("Gate");
    }

    // Update is called once per frame
    void Update()
    {
        if (openGate == true)
        {
            
            Physics2D.IgnoreLayerCollision(gateLayer, playerLayer, true);

        }
        if (openGate == false)
        {
            Physics2D.IgnoreLayerCollision(gateLayer, playerLayer, false);
        }
    }
    public void OpenGate()
    {
        openGate = true;
    }

}
