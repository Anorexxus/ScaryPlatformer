using UnityEngine;

public class Halucination : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 10)
        {
            Debug.Log("start");
            timer = 0;
            SpawnShade();
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }
    }
    void SpawnShade()
    {
        Debug.Log("strari");
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);
        Vector3 screenPos = new Vector3(randomX, randomY, 0);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        Instantiate(shadow, worldPos, shadow.transform.rotation);
    }
}
