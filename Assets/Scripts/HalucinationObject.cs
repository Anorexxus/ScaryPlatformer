using UnityEngine;

public class HalucinationObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool ghost = false;
    private float alpha = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
        if (alpha >= 1)
        {
            Debug.Log("boo");
            Destroy(gameObject);
        }

        if (ghost == true)
            {
                alpha -= 0.3f * Time.deltaTime;
                sr.color = new Color(0f, 0f, 0f, alpha);
            }
        if (ghost == false)
        {
            alpha += 0.1f * Time.deltaTime;
            sr.color = new Color(0f, 0f, 0f, alpha);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flash"))
        {
            ghost = true;
            
        }
    }
}
