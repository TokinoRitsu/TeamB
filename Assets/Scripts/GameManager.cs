using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStatus
    {
        WaitForRoomUpdate,
        Running,
        Paused,
        End
    }
    public gameStatus status;
    public List<Room> rooms;
    public int currentRoom;

    public GameObject roomPrefab;
    private void Awake()
    {
        status = gameStatus.WaitForRoomUpdate;
        rooms = new List<Room>();
        currentRoom = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        newRoom(0);
        StartCoroutine(countdown(1));
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void newRoom(int i)
    {
        int enemyCapacity = 2;
        int enemyTier = 1;
        int hpRewardCapacity = 1;
        int buffCapacity = 0;
        int buffTier = 0;
        int debuffCapacity = 0;
        int debuffTier = 0;

        if (i <= 3) enemyCapacity = (i + 1) * 2;
        else if (i <= 5) enemyCapacity = 12;
        else if (i <= 8) enemyCapacity = (i - 2) * 4;
        else if (i == 9) enemyCapacity = 30;

        if (i <= 1) enemyTier = 1;
        else if (i <= 4) enemyTier = 2;
        else if (i <= 6) enemyTier = 3;
        else if (i <= 8) enemyTier = 4;

        if (i <= 4) hpRewardCapacity = 1;

        if (i <= 1)
        {
            buffCapacity = 0;
            buffTier = 0;
            debuffCapacity = 0;
            debuffTier = 0;
        }
        else if (i <= 3)
        {
            buffCapacity = 1;
            buffTier = 1;
            debuffCapacity = 1;
            debuffTier = 1;
        }
        else if (i <= 4)
        {
            buffCapacity = 2;
            buffTier = 2;
            debuffCapacity = 2;
            debuffTier = 2;
        }
        rooms.Add(new Room(i, buffCapacity, buffTier, debuffCapacity, debuffTier, hpRewardCapacity, enemyCapacity, enemyTier));
        enterRoom(i);
    }

    private void enterRoom(int i)
    {
        GameObject roomObject = Instantiate(roomPrefab);
        roomObject.GetComponent<RoomController>().room = rooms[i];
    }

    private IEnumerator countdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        status = gameStatus.Running;
    }
}
