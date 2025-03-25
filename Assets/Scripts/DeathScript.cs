using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject DeathMenu;
public void Die()
    {
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
    }
}
