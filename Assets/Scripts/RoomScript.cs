using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    public Transform start;
    public List<RoomNumber> rooms;
    [SerializeField] GameObject[] startArray;
    private int currentRoomID = 1;

    void Start()
    {
        foreach (RoomNumber room in rooms)
        {
            room.gameObject.SetActive(room.RoomID == currentRoomID);
        }
    }
    private void Update()
    {
     
    }

    public void SwitchRoom()
    {
        int nextRoomID = currentRoomID + 1;

        RoomNumber currentRoom = rooms.Find(r => r.RoomID == currentRoomID);
        RoomNumber nextRoom = rooms.Find(r => r.RoomID == nextRoomID);

        if (currentRoom != null) currentRoom.gameObject.SetActive(false);
        if (nextRoom != null)
        {
            nextRoom.gameObject.SetActive(true);
            currentRoomID = nextRoomID;
            int startInt = rooms.IndexOf(nextRoom);
       if (startInt >= 0 && startInt < startArray.Length)
       {
        player.transform.position = startArray[startInt].transform.position;
       }
        }
       

        
    }
}
