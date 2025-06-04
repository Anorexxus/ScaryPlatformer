using UnityEngine;

public class RoomEntryScript : MonoBehaviour
{
    public RoomScript roomManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        roomManager.SwitchRoom();
        }
    }
}
