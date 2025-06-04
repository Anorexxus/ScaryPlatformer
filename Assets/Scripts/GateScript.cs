using UnityEngine;

public class GateScript : MonoBehaviour
{
    
    [SerializeField] bool openGate = false;
    
    private int playerLayer;
    private int gateLayer;
    [SerializeField]
    private SpriteRenderer sprite;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gateLayer, playerLayer, openGate);
        playerLayer = LayerMask.NameToLayer("Player");
        gateLayer = LayerMask.NameToLayer("Gate");
    }

    void Update()
    {
        if (openGate == true)
        {
            
            Physics2D.IgnoreLayerCollision(gateLayer, playerLayer, true);
            sprite.enabled = false;

        }
        if (openGate == false)
        {
            Physics2D.IgnoreLayerCollision(gateLayer, playerLayer, false);
            sprite.enabled = true;
        }
    }
    public void OpenGate()
    {
        openGate = true;
    }

}
