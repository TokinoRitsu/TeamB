using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public string roomShape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
     * ' ' = nothing
     * 'O' = floor
     * 'P' = Player Spawn Point
     * 'E' = Entrance
     * 'X' = Exit
     * Numbers = Enemy
     * Shift+Numbers = Enemy with heal
     * 
     *   OOO OOOO
     *  OOOO OOOO
     *  OOOO OOOO
     *  OOOO OOOO
     * XOOOO OOOPE
     *  OO@O O2OO
     *  OOOO OOOO
     *   OOO OOOO
    */

    public void GenerateRoom(string room)
    {
        foreach (char i in room)
        {
            switch (i)
            {
                case ' ':
                    break;

            }
        }
    }
}
