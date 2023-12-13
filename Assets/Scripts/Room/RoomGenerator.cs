using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{
    public Room room = new Room();
    
    public GameObject[] RoomTilePrefabs;

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
        room.roomShape = 
@"
 pjjjjjjj h
pcOOO OOOO 
lOOOO OOOOk
lOOOO OOOOk
lOOOO OOOOk
XOOOO OOOOE
lOOOO OOOOk
lOOOO OOOOk
lOOOO OOOOk
ndOOO OOOO 
 niiiiiii g";
        GenerateRoom(room.roomShape);
    }

    /*
     *  pjjjjjjj h
        pcOOO OOOO 
        lOOOO OOOOk
        lOOOO OOOOk
        lOOOO OOOOk
        XOOOO OOOOE
        lOOOO OOOOk
        lOOOO OOOOk
        lOOOO OOOOk
        ndOOO OOOO 
         niiiiiii g
    */

    public void GenerateRoom(string _roomShape)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        foreach (char i in _roomShape)
        {
            Debug.Log(i.ToString());
            if (i == '\n')
            {
                pos = new Vector3(0, pos.y, pos.z - 1);
            }
            else
            {
                GenerateTile(i, pos);
                pos = new Vector3(pos.x + 1, pos.y, pos.z);
            }
        }
    }

    public void GenerateTile(char tile, Vector3 pos)
    {
        if (tile != ' ' && tile != System.Environment.NewLine.ToCharArray()[0])
        {
            GameObject TileObject = Instantiate(GetGameObject(CharToName[tile]));
            TileObject.transform.position = pos;
        }
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
