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
        enterRoom(5);
        StartCoroutine(countdown(1));
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private Room newRoom(int i)
    {
        int roomShape = UnityEngine.Random.Range(0, 4);
        int enemyWave = 1;
        int enemyCapacity = i + 1;
        int enemyTier = 1;
        int buffCapacity = 0;
        int buffTier = 0;
        int trapCapacity = 0;
        bool doubleDamage = false;
        bool tripleDamage = false;

        if (i % 5 == 0)
        {
            enemyWave += UnityEngine.Random.Range(0, 3);
            enemyCapacity += UnityEngine.Random.Range(2, 5);
        }


        if (i <= 3) enemyTier = 1;
        else if (i <= 6) enemyTier = 2;
        else if (i <= 10) enemyTier = 3;
        else if (i != 20) enemyTier = UnityEngine.Random.Range(1, 6);


        if (i <= 2) buffCapacity = 0;
        else if (i <= 6) buffCapacity = 1;
        else if (i <= 9) buffCapacity = 3;
        else buffCapacity = i / 2 - 1;

        if (i <= 3) buffTier = 1;
        else if (i < 6) buffTier = 2;
        else if (i < 10) buffTier = 3;
        else buffTier = UnityEngine.Random.Range(1, 6);

        if (i <= 2) trapCapacity = 0;
        else if (i >= 7) trapCapacity = 1;

        if (trapCapacity >= 1)
        {
            if (i % 3 == 0) trapCapacity += UnityEngine.Random.Range(0, 4);
        }

        if (i >= 4)
        {
            if (UnityEngine.Random.Range(0, 5) == 0) doubleDamage = true;
            if (doubleDamage == false)
            {
                if (UnityEngine.Random.Range(0, 20) == 0) tripleDamage = true;
            }
        }

        return new Room(i, roomShape, buffCapacity, buffTier, trapCapacity, enemyCapacity, enemyTier, doubleDamage, tripleDamage, enemyWave);
    }

    private void enterRoom(int i)
    {
        GameObject roomObject = Instantiate(roomPrefab);
        roomObject.GetComponent<RoomController>().room = newRoom(i);
    }

    private IEnumerator countdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        status = gameStatus.Running;
    }
}
