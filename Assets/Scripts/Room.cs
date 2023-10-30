using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int roomID;

    public int buffCapacity;
    public int buffTier;
    public bool[] buffTaken;

    public int debuffCapacity;
    public int debuffTier;
    
    public int hpRewardCapacity;

    public int enemyCapacity;
    public int enemyTier;

    public bool cleared;

    public Room(int _roomID, int _buffCapacity, int _buffTier, int _debuffCapacity, int _debuffTier, int _hpRewardCapacity, int _enemyCapacity, int _enemyTier)
    {
        roomID = _roomID;
        buffCapacity = _buffCapacity;
        buffTier = _buffTier;
        debuffCapacity = _debuffCapacity;
        debuffTier = _debuffTier;
        hpRewardCapacity = _hpRewardCapacity;
        enemyCapacity = _enemyCapacity;
        enemyTier = _enemyTier;
        cleared = false;
    }
}
