using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int roomID;

    public int shape;

    public int buffCapacity;
    public int buffTier;
    public int[] buffs;

    public int trapCapacity;
    public int[] traps;

    public int enemyCapacity;
    public int enemyTier;

    public bool isDoubleDamage;
    public bool isTripleDamage;

    public int wave;
    public bool cleared;

    public Room(int _roomID, int _shape, int _buffCapacity, int _buffTier, int _trapCapacity, int _enemyCapacity, int _enemyTier, bool _isDoubleDamage, bool _isTripleDamage, int _wave)
    {
        roomID = _roomID;
        shape = _shape;
        buffCapacity = _buffCapacity;
        buffTier = _buffTier;
        trapCapacity = _trapCapacity;
        enemyCapacity = _enemyCapacity;
        enemyTier = _enemyTier;
        isDoubleDamage = _isDoubleDamage;
        isTripleDamage = _isTripleDamage;
        wave = _wave;
        cleared = false;
    }
}
