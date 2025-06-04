using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        bool isMoving = moveX != 0 || moveY != 0;
            
        animator.SetBool("isWalking", isMoving);
    }
}

