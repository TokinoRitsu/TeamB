using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData
{
    static public List<Room> roomData = new List<Room> { 
        new Room(@"
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
 niiiiiii g", 
            new List<Room.SpawnPoint>{
                new Room.SpawnPoint(7, -7, 0),
                new Room.SpawnPoint(3, -7, 0, true)
            },
            new List<Room.ItemSpawnPoint>{
                new Room.ItemSpawnPoint(2, 0, -2, 0),
                new Room.ItemSpawnPoint(9, 0, -2, 0),
                new Room.ItemSpawnPoint(2, 0, -10, 0),
                new Room.ItemSpawnPoint(9, 0, -10, 0)
            }),
        new Room(@"
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
 niiiiiii g",
            new List<Room.SpawnPoint>{
                new Room.SpawnPoint(7, -3, 0),
                new Room.SpawnPoint(7, -7, 0),
                new Room.SpawnPoint(3, -3, 0, true),
                new Room.SpawnPoint(3, -7, 0)
            },
            new List<Room.ItemSpawnPoint>{
                new Room.ItemSpawnPoint(2, 0, -2, 0),
                new Room.ItemSpawnPoint(9, 0, -2, 0),
                new Room.ItemSpawnPoint(2, 0, -10, 0),
                new Room.ItemSpawnPoint(9, 0, -10, 0)
            }),
        new Room(@"
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
 niiiiiii g",
            new List<Room.SpawnPoint>{
                new Room.SpawnPoint(7, -3, 0),
                new Room.SpawnPoint(7, -7, 0),
                new Room.SpawnPoint(3, -3, 0, true),
                new Room.SpawnPoint(3, -7, 1)
            },
            new List<Room.ItemSpawnPoint>{
                new Room.ItemSpawnPoint(2, 0, -2, 0),
                new Room.ItemSpawnPoint(9, 0, -2, 0),
                new Room.ItemSpawnPoint(2, 0, -10, 0),
                new Room.ItemSpawnPoint(9, 0, -10, 0)
            }),

    };
}
