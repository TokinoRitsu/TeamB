using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class RoomGenerator : MonoBehaviour
{
    public Room room;

    public GameObject PlayerPrefab;
    public GameObject[] RoomTilePrefabs;
    public GameObject[] RoomItemPrefabs;
    public GameObject[] MobPrefabs;

    GameObject[] walkable;
    List<NavMeshSurface> navMeshSurfaces = new List<NavMeshSurface>();

    private Dictionary<char, string> CharToName = new Dictionary<char, string>
    {
        { 'O', "Floor1" },
        { 'E', "Entrance" },
        { 'X', "Exit" },
        { 'a', "WallInnerL" },
        { 'b', "WallInnerGamma" },
        { 'c', "WallInnerReverseL" },
        { 'd', "WallInnerReverseGamma" },
        { 'e', "WallOuterL" },
        { 'f', "WallOuterGamma" },
        { 'g', "WallOuterReverseL" },
        { 'h', "WallOuterReverseGamma" },
        { 'i', "WallUp" },
        { 'j', "WallDown" },
        { 'k', "WallLeft" },
        { 'l', "WallRight"},
        { 'm', "WallUL"},
        { 'n', "WallUR"},
        { 'o', "WallDL"},
        { 'p', "WallDR"},
    };
    // Start is called before the first frame update
    void Start()
    {
        room = RoomData.roomData[GameObject.Find("ValueHolder").GetComponent<ValueHolder>().currentRoom];
        GenerateRoom(room.roomShape);
        GenerateItems(room.itemSpawnPoints);
        GenerateMobs(room.spawnPoints);
        //NavMesh
        walkable = GameObject.FindGameObjectsWithTag("Walkable");
        for (int i = 0; i < walkable.Length; i++)
        {
            navMeshSurfaces.Add(walkable[i].transform.GetChild(0).GetComponent<NavMeshSurface>());
        }
        foreach (NavMeshSurface nef in navMeshSurfaces)
        {
            nef.BuildNavMesh();
        }
        GeneratePlayer();

        

    }

    public void GenerateRoom(string _roomShape)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        GameObject parentObject = new GameObject();
        parentObject.name = "RoomObject";
        foreach (char i in _roomShape)
        {
            if (i == '\n')
            {
                pos = new Vector3(0, pos.y, pos.z - 1);
            }
            else
            {
                GenerateTile(i, pos, parentObject.transform);
                pos = new Vector3(pos.x + 1, pos.y, pos.z);
            }
        }
    }

    public void GenerateItems(List<Room.ItemSpawnPoint> _spawnPoints)
    {
        foreach (Room.ItemSpawnPoint i in _spawnPoints)
        {
            GameObject itemObject = Instantiate(RoomItemPrefabs[i.index]);
            itemObject.transform.position = i.pos;
        }
    }

    public void GenerateMobs(List<Room.SpawnPoint> _spawnPoints)
    {
        foreach(Room.SpawnPoint i in _spawnPoints)
        {
            GameObject mobObject = Instantiate(MobPrefabs[i.index]);
            mobObject.GetComponent<EnemyController>().hasHPReward = i.hasHeal;
            mobObject.transform.position = i.pos;
        }
    }

    public void GenerateTile(char tile, Vector3 pos, Transform parent)
    {
        if (tile != ' ' && tile != System.Environment.NewLine.ToCharArray()[0])
        {
            GameObject TileObject = Instantiate(GetGameObject(CharToName[tile]));
            TileObject.transform.position = pos;
            TileObject.transform.SetParent(parent);
        }
    }

    public void GeneratePlayer()
    {
        GameObject EntranceObject = GameObject.FindGameObjectWithTag("Entrance");
        GameObject PlayerObject = Instantiate(PlayerPrefab);
        PlayerObject.transform.position = EntranceObject.transform.position;
    }

    public GameObject GetGameObject(string _name)
    {
        GameObject result = null;
        foreach (GameObject _object in RoomTilePrefabs)
        {
            if (_object.name == _name)
            {
                result = _object;
                break;
            }
        }
        return result;
    }


}
