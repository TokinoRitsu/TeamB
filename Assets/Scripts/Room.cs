using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Room : ScriptableObject
{
    public int bonusCost;
    public int enemyCost;
    public int wave;
    public int enemyTier;
    public Room(int _bonusCost, int _enemyCost, int _wave, int _enemyTier)
    {
        bonusCost = _bonusCost;
        enemyCost = _enemyCost;
        wave = _wave;
        enemyTier = _enemyTier;
    }
}
